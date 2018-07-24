using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlazorLib3
{
    public class LupParser
    {
        public List<HtmlElement> HtmlElements_List = new List<HtmlElement>();

        string _raw_html_Origin;
        string _html;

        public List<MyItem> _MyItems_List = new List<MyItem>();



        public LupParser(string raw_html)
        {
            HtmlElements_List = new List<HtmlElement>();
            _MyItems_List = new List<MyItem>();
            _raw_html_Origin = raw_html;
            _html = _raw_html_Origin;
        }

        public void Display_Error(string Par_Message)
        {

            HtmlElement HtmlElement1 = new HtmlElement();

            HtmlElement1.Name = "h1";
            HtmlElement1.attributes.Add("style", "color:red");

            HtmlElement1.Content = "Error: " + Par_Message;

            HtmlElements_List.Add(HtmlElement1);
        }



        public bool Validate()
        {
            HtmlElements_List = new List<HtmlElement>();

            if (string.IsNullOrEmpty(_html.Trim()))
            {
                Display_Error("Raw html is empty!");
                return false;
            }

            if (_html.ToLower().Contains("script"))
            {
                Display_Error("detected script in input!");
                return false;
            }

            return true;
        }

        public void Parse()
        {
            int k = 0;
            string a = string.Empty;
            bool b;

            _html = Regex.Replace(_html, @"\r\n?|\n", " ");


            _html = _html.Replace(@"/", "|");


            Remove_Double_Space();


            List<string> tmp_list = _html.Split('>').ToList();

            for (int i = 0; i < tmp_list.Count; i++)
            {
                tmp_list[i] = tmp_list[i].Trim();
            }

            tmp_list.RemoveAll(x => string.IsNullOrEmpty(x));



            for (int i = 0; i < tmp_list.Count; i++)
            {
                tmp_list[i] = tmp_list[i] + ">";
            }

            for (int i = 0; i < tmp_list.Count; i++)
            {
                if (tmp_list[i].IndexOf("<") > 0)
                {
                    k = tmp_list[i].IndexOf("<");
                    a = tmp_list[i];
                    tmp_list[i] = a.Substring(0, k).Trim();
                    tmp_list.Insert(i + 1, a.Substring(k, a.Length - k).Trim());
                    i++;
                }

            }

            tmp_list.RemoveAll(x => string.IsNullOrEmpty(x));



            foreach (var item in tmp_list)
            {
                b = item.Contains("<") || item.Contains(">");
                _MyItems_List.Add(new MyItem() { Rawhtml = item.Trim(), IsCloseTag = false, IsContent = !b });
            }

            tmp_list = new List<string>();



            for (int i = 0; i < _MyItems_List.Count; i++)
            {
                if (!_MyItems_List[i].IsContent)
                {
                    _MyItems_List[i].TagName = Extract_Tag_Name(_MyItems_List[i].Rawhtml);
                }
            }



            for (int i = 0; i < _MyItems_List.Count; i++)
            {
                if (!_MyItems_List[i].IsContent)
                {
                    if (_MyItems_List[i].Rawhtml.Contains("|>"))
                    {
                        a = Replace_Self_Closing_Tag(_MyItems_List[i].TagName);

                        _MyItems_List[i].Rawhtml = _MyItems_List[i].Rawhtml.Replace("|>", ">");
                        _MyItems_List.Insert(i + 1, new MyItem() { Rawhtml = a, TagName = _MyItems_List[i].TagName, IsCloseTag = true });
                        i++;
                    }
                }

            }



            for (int i = 0; i < _MyItems_List.Count; i++)
            {
                _MyItems_List[i].IsCloseTag = _MyItems_List[i].Rawhtml.Contains("<|" + _MyItems_List[i].TagName + ">");
                _MyItems_List[i].ID = i + 1;
                _MyItems_List[i].ParentID = i + 1;

            }





            foreach (var item in _MyItems_List.Where(x => x.IsCloseTag))
            {
                item.CloseID = Get_Close_ID(item);

            }



            foreach (var item in _MyItems_List.Where(x => !x.IsCloseTag && !x.IsContent).OrderBy(x => x.ID))
            {

                Set_Parent(item);
            }


            _MyItems_List.RemoveAll(x => x.IsCloseTag);

            foreach (var item in _MyItems_List.Where(x => !x.IsCloseTag && !x.IsContent).OrderBy(x => x.ID))
            {

                item.IsParent = _MyItems_List.Any(x => x.ParentID == item.ID && x.Level > item.Level);
            }




            foreach (var item in _MyItems_List.Where(x => !x.IsCloseTag && !x.IsContent))
            {
                if (item.Rawhtml != "<" + item.TagName + ">")
                {
                    item.HasAttributes = true;
                    item.Attributeshtml = item.Rawhtml.Replace("<" + item.TagName, "");

                    item.Attributeshtml = item.Attributeshtml.Replace(">", "").Trim();
                    item.Attributeshtml = Notmalize_Attribute(item.Attributeshtml);
                    item.Attributeshtml = item.Attributeshtml.Replace("\"", "").Trim();

                    if (!item.IsContent)
                    {
                        item.Rawhtml = string.Empty;
                    }
                }
            }



            foreach (var item in _MyItems_List.Where(x => !x.IsCloseTag && !x.IsContent && x.Level == 0).OrderBy(x => x.ID))
            {
                HtmlElements_List.Add(Get_Children(item));
            }



            _MyItems_List = new List<MyItem>();

            //     _MyItems_List.RemoveAll(x => x.IsContent);

            // Print_List();
        }


        public void Print_List()
        {

            foreach (var item in HtmlElements_List)
            {
                Print_Item(item);
            }

        }

        public void Print_Item(HtmlElement Par_Item)
        {

            string a = string.Empty;

            for (int i = 0; i < Par_Item.Level; i++)
            {
                a += "-";
            }


            Console.WriteLine(a + Par_Item.Name + " " + Par_Item.Content);

            if (Par_Item.children.Any())
            {
                foreach (var item in Par_Item.children)
                {
                    Print_Item(item);
                }
            }
        }


        public HtmlElement Get_Children(MyItem Par_Item)
        {



            HtmlElement new_HtmlElement = new HtmlElement();
            new_HtmlElement.MyItemID = Par_Item.ID;
            new_HtmlElement.Level = Par_Item.Level;
            new_HtmlElement.Name = Par_Item.TagName;
            new_HtmlElement.Content = Get_Content(Par_Item);
            if (Par_Item.HasAttributes)
            {
                new_HtmlElement.attributes = Get_Attributes(Par_Item);
                Par_Item.Attributeshtml = string.Empty;
            }

            if (Par_Item.IsParent)
            {

                foreach (var item in _MyItems_List.Where(x => x.ParentID == Par_Item.ID && x.Level > Par_Item.Level))
                {
                    new_HtmlElement.children.Add(Get_Children(item));
                }


            }



            return new_HtmlElement;
        }

        public string Notmalize_Attribute(string a)
        {
            string result = string.Empty;
            string b = string.Empty;



            bool isOpen = false;

            for (int i = 0; i < a.Length; i++)
            {
                b = a.Substring(i, 1);
                if (b == "\"")
                {
                    isOpen = !isOpen;
                }

                if (isOpen && b == " ")
                {
                    b = "!@#$+$#@!";
                }

                result += b;

            }


            return result;
        }

        public Dictionary<string, string> Get_Attributes(MyItem _Parent_Item)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            string[] attr_array = _Parent_Item.Attributeshtml.Split(' ');

            string[] a;

            for (int i = 0; i < attr_array.Length; i++)
            {
                a = attr_array[i].Split('=');

                result.Add(a[0], a[1].Replace("!@#$+$#@!", " "));
            }

            return result;
        }


        public string Get_Content(MyItem _Parent_Item)
        {
            if (_MyItems_List.Any(x => x.IsContent && x.ParentID == _Parent_Item.ID))
            {
                return _MyItems_List.Single(x => x.IsContent && x.ParentID == _Parent_Item.ID).Rawhtml;
            }

            return string.Empty;
        }

        public void Set_Parent(MyItem Parent_item)
        {
            foreach (var item in _MyItems_List.Where(x => x.ID > Parent_item.ID && x.ID <= Parent_item.CloseID))
            {

                item.ParentID = Parent_item.ID;
                item.Level = item.Level + 1;
            }
        }

        public int Get_Close_ID(MyItem _item)
        {
            int k = -1;
            if (_MyItems_List.Where(x => x.ID < _item.ID && x.CloseID == 0 && !x.IsCloseTag && !x.IsContent).OrderByDescending(x => x.ID).Any(x => x.TagName == _item.TagName))
            {


                k = _MyItems_List.Where(x => x.ID < _item.ID && x.CloseID == 0 && !x.IsCloseTag && !x.IsContent).OrderByDescending(x => x.ID).First(x => x.TagName == _item.TagName).ID;

                _MyItems_List.Single(x => x.ID == k).CloseID = _item.ID;
            }
            else
            {
                MyFunctions.Display_Message("Not found with tag is closing!", MethodBase.GetCurrentMethod());
            }


            return k;

        }

        public string Replace_Self_Closing_Tag(string tagName)
        {

            return "<|" + tagName + ">";

        }


        public string Extract_Tag_Name(string input)
        {
            int i1 = 0;
            int i2 = 0;


            if (input.Contains("<|"))
            {
                i1 = input.LastIndexOf("<|") + 1;

            }
            else
            {
                i1 = input.LastIndexOf("<");
            }



            if (input.Contains(" "))
            {
                i2 = input.IndexOf(" ", i1);
            }
            else if (input.Contains("|>"))
            {
                i2 = input.IndexOf("|>", i1);
            }
            else
            {
                i2 = input.IndexOf(">", i1);
            }


            if (i1 == -1)
            {
                MyFunctions.Display_Message("!", MethodBase.GetCurrentMethod());
            }

            if (i2 == -1)
            {
                MyFunctions.Display_Message("!", MethodBase.GetCurrentMethod());
            }

            if (i2 > i1)
            {

                return input.Substring(i1 + 1, i2 - i1 - 1);
            }
            else
            {
                MyFunctions.Display_Message("!", MethodBase.GetCurrentMethod());
            }

            return string.Empty;
        }

        public void Remove_Double_Space()
        {
            if (_html.IndexOf("  ") > -1)
            {
                _html = _html.Replace("  ", " ");
                Remove_Double_Space();
            }
        }




    }
}
