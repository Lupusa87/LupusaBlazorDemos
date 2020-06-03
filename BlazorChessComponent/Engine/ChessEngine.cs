using BlazorSvgHelper.Classes;
using BlazorSvgHelper.Classes.SubClasses;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorChessComponent.Engine
{
    public class ChessEngine
    {
        
        public CompSettings compSettings = new CompSettings();

        public myCell MyCell = new myCell("lightyellow", "#FFA500");

        bool aqvs_roqis_ufleba = true;
        bool aqvs_mokle_roqis_ufleba = true;
        bool aqvs_grdzeli_roqis_ufleba = true;

        bool Player_Has_Shax = false;
        bool Opposite_Has_Shax = false;

        bool Drag_Mode = false;
        bool Drag_Figure_isDefined = false;

        bool Replay_Mode = true;
        bool Select_New_Figure_Mode = false;
        int Select_New_Figure_X = -1;


        public myCell MyCell_Moklulebi = new myCell("white", "#FFA500");


        myPoint MyPoint = new myPoint();

        int Current_Move = 1;

        public int PlayerColor = 1;
        public int OppositeColor = 2;

        int Player_Total_Seconds = 300; //60*5
        int Opposite_Total_Seconds = 300;


        

        List<string> Board_Array_moklulebi_Player_Color = new List<string>();
        List<string> Board_Array_moklulebi_Opposite_Color = new List<string>();

        string[] Board_Array_ImageFiles = new string[] { "1P", "1R", "1K", "1B", "1Q", "1A", "2P", "2R", "2K", "2B", "2Q", "2A" };

        public string[] Board_Array_Letters = new string[] { "A", "B", "C", "D", "E", "F", "G", "H" };

        List<string> Board_Array_potenciuri_svlebi = new List<string>();
        List<int> Board_Array_potenciuri_gavlit_mosaklavi_paiki = new List<int>();  // x კოორდინატს ვინახავთ მარტო იმის დასადგენად მარჯვენაა თუ მარცხენა, y ყოველთვის 4 იქნება

        string[] Board_Array_Moves = new string[] { "A2A3", "I7I6", "B1C3", "H7H6" };
        int Curr_Replay_Index = 0;

        int loaded_Images = 0;


        public myColors MyColors = new myColors();

        public mylineWidths MylineWidths = new mylineWidths();


        public bool ar_avantot_ujrebi;


        Timer timer_Replay;
        Timer timer_Game;

       

        myFigure Curr_Figure = new myFigure();

        myFigure Next_Figure = new myFigure();

        myFigure tmp_Figure = new myFigure();


        string All_Figures = "PRKBQA";
        string All_Figures_Without_King = "PRKBQ";


        // let Board_Array: string[] =
        //     ["e", "e", "e", "e", "e", "a", "e", "e",
        //         "p", "e", "e", "e", "e", "e", "e", "R",
        //         "e", "e", "e", "e", "e", "K", "e", "e",
        //         "e", "e", "e", "e", "e", "e", "e", "e",
        //         "P", "e", "e", "e", "e", "e", "e", "e",
        //         "e", "e", "e", "e", "e", "e", "e", "e",
        //         "e", "e", "e", "e", "e", "e", "e", "e",
        //         "e", "A", "e", "e", "e", "e", "e", "e"];

        public string[] Board_Array = new string[] {
        "r", "k", "b", "q", "a", "b", "k", "r",
        "p", "p", "p", "p", "p", "p", "p", "p",
        "e", "e", "e", "e", "e", "e", "e", "e",
        "e", "e", "e", "e", "e", "e", "e", "e",
        "e", "e", "e", "e", "e", "e", "e", "e",
        "e", "e", "e", "e", "e", "e", "e", "e",
        "P", "P", "P", "P", "P", "P", "P", "P",
        "R", "K", "B", "Q", "A", "B", "K", "R"};

        string Board_Scheme = "rkbqabkrppppppppeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeePPPPPPPPRKBQABKR";




        

        public ChessEngine(bool PlayerOrOpposite)
        {
            if (PlayerOrOpposite)
            {
                PlayerColor = 1;
                OppositeColor = 2;

                Current_Move = 1;

            }
            else
            {
                Reverse_Board();

                PlayerColor = 2;
                OppositeColor = 1;

                Current_Move = 1;
            }


           
        }

        public void GetBoundingClientRect(string RectID)
        {
            BChessCJsInterop.GetElementBoundingClientRect(RectID, DotNetObjectReference.Create(this));
        }

        public void StartTimer()
        {
            if (timer_Game == null)
            {
                timer_Game = new Timer(TimerGameCallback, null, 1000, 1000);
            }
        }



        void Opposite_Has_Made_Move()
        {
            
            
        }

       

        public void cmd_mouseDown(MouseEventArgs e)
        {
            
            compSettings.rects_list = new List<rect>();
            if (Current_Move == PlayerColor)
            {
                Drag_Mode = true;
                Drag_Figure_isDefined = false;
              //  JsInterop.SetCursor("move");
                

                double x = e.ClientX - compSettings.BoardPositionX - MyCell.width * 0.5;
                double y = e.ClientY - compSettings.BoardPositionY - MyCell.height * 0.5;

                if (x > 0 && y > 0)
                {
                    Select_Cell(x, y);
                }
            }
        }

        public void cmd_mouseUp(MouseEventArgs e)
        {

            if (Current_Move == PlayerColor)
            {
                Drag_Mode = false;

                if (Drag_Figure_isDefined)
                {
                    ujraze_figuris_dasma(Curr_Figure.X, Curr_Figure.Y, Curr_Figure.kodi);
                    Drag_Figure_isDefined = false;
                }

               
                BChessCJsInterop.SetCursor();

                double x = e.ClientX - compSettings.BoardPositionX - MyCell.width * 0.5;
                double y = e.ClientY - compSettings.BoardPositionY - MyCell.height * 0.5;

                if (x > 0 && y > 0)
                {
                    Select_Cell(x, y);
                }
            }

        }



        void mausis_gasvla_dafidan()
        {

            Drag_Mode = false;

            if (Drag_Figure_isDefined)
            {
                ujraze_figuris_dasma(Curr_Figure.X, Curr_Figure.Y, Curr_Figure.kodi);
                Drag_Figure_isDefined = false;
            }

            //compSettings.Curr_Comp_Board.Refresh();
            Clear_Curr_And_Next_Figures();
        }

        public void cmd_mouseMove(MouseEventArgs e)
        {
            if (Current_Move == PlayerColor)
            {
                if (Select_New_Figure_Mode)
                {
                   

                    double x = e.ClientX - compSettings.BoardPositionX - MyCell.width * 0.5;
                    double y = e.ClientY - compSettings.BoardPositionY - MyCell.height * 0.5;

                    if (x > 0 && y > 0)
                    {

                        double My_x = x - x % MyCell.width;
                        double My_y = y - y % MyCell.height;

                        int Curr_X = (int)Math.Floor(My_x / MyCell.width);
                        int Curr_Y = (int)Math.Floor(My_y / MyCell.height);


                        if (Curr_X >= 0 && Curr_X <= 7 && Curr_Y >= 0 && Curr_Y <= 7)
                        {

                            if (Curr_X == Select_New_Figure_X && Curr_Y < 4)
                            {
                                paikis_gayvana(Select_New_Figure_X, Curr_Y);
                            }
                        }
                    }
                }
                else
                {
                    if (Drag_Mode)
                    {


                        if (Drag_Figure_isDefined == false)
                        {

                            ujris_gatavisufleba(Curr_Figure.X, Curr_Figure.Y);
                            Drag_Figure_isDefined = true;
                        }


                        

                        double x = e.ClientX - compSettings.BoardPositionX - MyCell.width * 0.5;
                        double y = e.ClientY - compSettings.BoardPositionY - MyCell.height * 0.5;

                        if (x > 0 && y > 0)
                        {

                            double My_x = x - x % MyCell.width;
                            double My_y = y - y % MyCell.height;

                            double Curr_X = Math.Floor(My_x / MyCell.width);
                            double Curr_Y = Math.Floor(My_y / MyCell.height);


                            if (Curr_X >= 0 && Curr_X <= 7 && Curr_Y >= 0 && Curr_Y <= 7)
                            {

                               // compSettings.Curr_Comp_Board.Refresh();
                               // context_Board.drawImage(game_Images[PlayerColor.ToString() + Curr_Figure.kodi.ToUpper()], x, y, MyCell.width, MyCell.height);
                            }
                            else
                            {
                                mausis_gasvla_dafidan();
                            }
                        }
                        else
                        {

                            mausis_gasvla_dafidan();

                        }
                    }
                }
            }

        }

        bool is_my_figure(string p, int par_visi_poziciidan)
        {

            if (p == "e")
            {
                return false;
            }
            if (par_visi_poziciidan == 1)
            {
                return !MyFunctions.is_lower_case(p);
            }
            else
            {
                return MyFunctions.is_lower_case(p);
            }

        }

        

        bool Get_Cell_Color_By_Coordinates(int x, int y)
        {
            return MyFunctions.Get_Cell_Color_By_Index(Get_Board_Index(x, y));
        }

        void Select_Cell(double x, double y)
        {
            double My_x = x - x % MyCell.width;
            double My_y = y - y % MyCell.height;
           
            int Curr_X = (int)Math.Floor(My_x / MyCell.width);
            int Curr_Y = (int)Math.Floor(My_y / MyCell.height);

          
            if (Curr_X >= 0 && Curr_X <= 7 && Curr_Y >= 0 && Curr_Y <= 7)
            {
              
                if (Select_New_Figure_Mode == false)
                {
                
                    int Curr_index = Get_Board_Index(Curr_X, Curr_Y);
                 
                    string kodi = Board_Array[Curr_index].ToString();
                  
                    if (Curr_Figure.isDefined == false)
                    {
                      
                        monishvnuli_figuris_anteba(My_x, My_y, Curr_X, Curr_Y, Curr_index, kodi);
                    }
                    else
                    {
                    
                        if ((Curr_Figure.X == Curr_X) && (Curr_Figure.Y == Curr_Y))  // ვამოწმებთ თავის თავზე!
                        {
                            // არაფერს არ ვაკეთებთ
                            //compSettings.Curr_Comp_Board.Refresh();
                        }
                        else
                        {
                            if (Board_Array_potenciuri_svlebi.ToList().IndexOf(Curr_X.ToString() + Curr_Y.ToString()) > -1)
                            {

                                Next_Figure.isDefined = true;
                                Next_Figure.X = Curr_X;
                                Next_Figure.Y = Curr_Y;
                                Next_Figure.index = -1;
                                Next_Figure.kodi = kodi;
                                svlis_gaketeba_Player();
                            }
                            else
                            {
                                Clear_Curr_And_Next_Figures();
                            }
                        }
                    }
                }
                else
                {
                    if (Curr_X == Select_New_Figure_X)
                    {

                        string Par_Extra = "Q";
                        switch (Curr_Y)
                        {
                            case 1:
                                Par_Extra = "R";
                                break;
                            case 2:
                                Par_Extra = "B";
                                break;
                            case 3:
                                Par_Extra = "K";
                                break;
                            default:
                                Par_Extra = "Q";
                                break;
                        }


                        string old_Code = Board_Array[Get_Board_Index(Curr_Figure.X, Curr_Figure.Y)];

                        if (PlayerColor == 2)
                        {
                            Par_Extra = Par_Extra.ToLower();
                        }

                        Curr_Figure.kodi = Par_Extra;
                        Board_Array[Get_Board_Index(Curr_Figure.X, Curr_Figure.Y)] = Par_Extra;

                        ujraze_mimdinare_figuris_dasma(Next_Figure.X, Next_Figure.Y);
                        ujris_gatavisufleba(Curr_Figure.X, Curr_Figure.Y);


                        svlis_chawera("=" + Par_Extra);

                        Clear_Curr_And_Next_Figures();


                        Select_New_Figure_Mode = false;
                        Select_New_Figure_X = -1;
                        

                    }
                }
            }
        }

        void monishvnuli_figuris_anteba(double My_x, double My_y, int Curr_X, int Curr_Y, int Curr_index, string kodi)
        {
            if (kodi != "e")
            {

                if (is_my_figure(kodi, PlayerColor))
                {

                    compSettings.rects_list.Add(new rect
                    {
                        x = My_x + MyCell.width / 2 + MylineWidths.selected_cell,
                        y = My_y + MyCell.height / 2 + MylineWidths.selected_cell,
                        width = MyCell.width - MylineWidths.selected_cell * 2,
                        height = MyCell.height - MylineWidths.selected_cell * 2,
                        fill="none",
                        stroke = MyColors.selected_cell,
                        stroke_width = MylineWidths.selected_cell,
                    });


                    

                    Curr_Figure.isDefined = true;
                    Curr_Figure.X = Curr_X;
                    Curr_Figure.Y = Curr_Y;
                    Curr_Figure.index = Curr_index;
                    Curr_Figure.kodi = kodi;

                    Find_Moves(PlayerColor);

                    
                }
                else
                {
                    Clear_Curr_And_Next_Figures();
                }
            }
            else
            {
                Clear_Curr_And_Next_Figures();
            }
        }

        bool figuris_gadaadgilebit_ixsneba_shaxi()
        {

            bool result = false;


            if (Curr_Figure.kodi.ToLower() != "a")
            {


                // დროებით ფიგურის აღება რომ შემოწმდეს იხსნება თუ არა შახი
                ujris_gatavisufleba(Curr_Figure.X, Curr_Figure.Y);

                string King_Letter = "A";

                if (PlayerColor == 2)
                {
                    King_Letter = King_Letter.ToLower();
                }

                // მეფის კოორდინატების მოძებნა
                int King_X = 0;
                int King_Y = 0;

                int King_Index = Board_Array.ToList().IndexOf(King_Letter);

                if (King_Index > -1)
                {

                    King_X = (King_Index) % 8;
                    King_Y = (King_Index - King_X) / 8;

                    result = ujra_aris_tu_ara_muqaris_qvesh(King_X, King_Y, PlayerColor);
                }
                else
                {
                    BChessCJsInterop.alert("არალოგიკური შეცდომა, მეფე ვერ მოიძებნა დაფაზე! (function figuris_gadaadgilebit_ixsneba_shaxi)");
                }

                // აღებული ფიგურის დაბრუნება თავის პოზიციაზე
                ujraze_figuris_dasma(Curr_Figure.X, Curr_Figure.Y, Curr_Figure.kodi);
            }

            return result;
        }

        public void acxadebs_shaxs_an_gardes(int par_vin_acxadebs)
        {
            string King_Letter = string.Empty;
            string Queen_Letter = string.Empty;

            double My_x = 0;
            double My_y = 0;

            int mowinaaRmdege = 0;

            if (par_vin_acxadebs == 1)
            {
                King_Letter = "a";
                Queen_Letter = "q";
                mowinaaRmdege = 2;
            }
            else
            {
                King_Letter = "A";
                Queen_Letter = "Q";
                mowinaaRmdege = 1;
            }

            if (mowinaaRmdege == OppositeColor)
            {
                Opposite_Has_Shax = false;
            }
            else
            {
                Player_Has_Shax = false;
            }


            //მეფის კოორდინატების მოძებნა
            int tmp_X = 0;
            int tmp_Y = 0;

            int tmp_Index = Board_Array.ToList().IndexOf(King_Letter);


            if (tmp_Index > -1)
            {

                tmp_X = (tmp_Index) % 8;
                tmp_Y = (tmp_Index - tmp_X) / 8;

                if (ujra_aris_tu_ara_muqaris_qvesh(tmp_X, tmp_Y, mowinaaRmdege))
                {
                    if (mowinaaRmdege == 2)
                    {
                        Opposite_Has_Shax = true;
                    }
                    else
                    {
                        Player_Has_Shax = true;


                    }

                    if (!ar_avantot_ujrebi)
                    {
                        My_x = tmp_X * MyCell.width + MyCell.width * 0.5;
                        My_y = tmp_Y * MyCell.height + MyCell.height * 0.5;

                        compSettings.rects_list.Add(new rect
                        {
                            x = My_x + MylineWidths.shaxi_an_garde,
                            y = My_y + MylineWidths.shaxi_an_garde,
                            width = MyCell.width - MylineWidths.selected_cell * 2,
                            height = MyCell.height - MylineWidths.selected_cell * 2,
                            fill = "none",
                            stroke = MyColors.shaxi_an_garde,
                            stroke_width = MylineWidths.shaxi_an_garde,
                        });

                    }
                }
                else
                {
                    if (mowinaaRmdege == 2)
                    {
                        Opposite_Has_Shax = false;
                    }
                    else
                    {
                        Player_Has_Shax = false;
                    }
                }
            }

            tmp_Index = Board_Array.ToList().IndexOf(Queen_Letter);

            if (tmp_Index > -1)
            {

                tmp_X = (tmp_Index) % 8;
                tmp_Y = (tmp_Index - tmp_X) / 8;

                if (ujra_aris_tu_ara_muqaris_qvesh(tmp_X, tmp_Y, mowinaaRmdege))
                {
                    if (!ar_avantot_ujrebi)
                    {
                        My_x = tmp_X * MyCell.width + MyCell.width * 0.5;
                        My_y = tmp_Y * MyCell.height + MyCell.height * 0.5;

                        compSettings.rects_list.Add(new rect
                        {
                            x = My_x + MylineWidths.shaxi_an_garde,
                            y = My_y + MylineWidths.shaxi_an_garde,
                            width = MyCell.width - MylineWidths.selected_cell * 2,
                            height = MyCell.height - MylineWidths.selected_cell * 2,
                            fill = "none",
                            stroke = MyColors.shaxi_an_garde,
                            stroke_width = MylineWidths.shaxi_an_garde,
                        });
                    }
                }
            }


        }

        void Game_Over(string t)
        {
            if (timer_Game != null)
            {
                timer_Game.Dispose();
            }
            
            BChessCJsInterop.alert("Game over - " + t);
        }

        void Clear_Curr_And_Next_Figures()
        {

            Curr_Figure.isDefined = false;
            Curr_Figure.X = -1;
            Curr_Figure.Y = -1;
            Curr_Figure.index = -1;
            Curr_Figure.kodi = "";

            Next_Figure.isDefined = false;
            Next_Figure.X = -1;
            Next_Figure.Y = -1;
            Next_Figure.index = -1;
            Next_Figure.kodi = "";
        }

        void myLog(string text)
        {
            compSettings.Log_list.Add(text);
        }

        void ujris_anteba(int x, int y, int par_visi_poziciidan)
        {

            if (Curr_Figure.kodi.ToLower() == "a" && ujra_aris_tu_ara_muqaris_qvesh(x, y, par_visi_poziciidan))
            {
                // არ ვანთებთ უჯრას
            }
            else
            {
                if (Can_Move(x, y, par_visi_poziciidan))
                {

                    Board_Array_potenciuri_svlebi.Add(x + "" + y);

                    if (!ar_avantot_ujrebi)
                    {
                        double My_x = x * MyCell.width + MyCell.width * 0.5;
                        double My_y = y * MyCell.height + MyCell.height * 0.5;



                        compSettings.rects_list.Add(new rect
                        {
                            x = My_x + MylineWidths.potenciuri_svla,
                            y = My_y + MylineWidths.potenciuri_svla,
                            width = MyCell.width - MylineWidths.selected_cell * 2,
                            height = MyCell.height - MylineWidths.selected_cell * 2,
                            fill = "none",
                            stroke = MyColors.potenciuri_svla,
                            stroke_width = MylineWidths.potenciuri_svla,
                        });
                    }
                }
            }

        }

        bool Can_Move(int x, int y, int par_visi_poziciidan)
        {
            bool result = true;
            bool tmp_saved_state = ar_avantot_ujrebi;

            ar_avantot_ujrebi = true;

            string[] tmp_array = Board_Array.Clone() as string[];

            if (par_visi_poziciidan == PlayerColor)
            {
                Player_Has_Shax = false;
            }
            else
            {
                Opposite_Has_Shax = false;
            }



            Next_Figure.isDefined = true;
            Next_Figure.X = x;
            Next_Figure.Y = y;
            Next_Figure.index = Get_Board_Index(Next_Figure.X, Next_Figure.Y);
            Next_Figure.kodi = Board_Array[Next_Figure.index];


            fiqtiuri_svlis_gaketeba();

            Next_Figure.isDefined = false;
            Next_Figure.X = -1;
            Next_Figure.Y = -1;
            Next_Figure.index = -1;
            Next_Figure.kodi = "";

            if (par_visi_poziciidan == PlayerColor)
            {

                // თუ ამ სვლის გაკეთების შემდეგ მეფეს გაეხსნება შახი, ან არსებული შახი არ მოეხსნება, ეს სვლა უარყოფილია
                acxadebs_shaxs_an_gardes(OppositeColor);
                result = !Player_Has_Shax;

            }
            else
            {

                // თუ ამ სვლის გაკეთების შემდეგ მეფეს გაეხსნება შახი, ან არსებული შახი არ მოეხსნება, ეს სვლა უარყოფილია
                acxadebs_shaxs_an_gardes(PlayerColor);
                result = !Opposite_Has_Shax;

            }

            Board_Array = tmp_array.Clone() as string[];

            ar_avantot_ujrebi = tmp_saved_state;
            return result;
        }

        void Find_Moves(int par_visi_poziciidan)
        {
            Board_Array_potenciuri_svlebi = new List<string>();
            Board_Array_potenciuri_gavlit_mosaklavi_paiki = new List<int>();

            switch (Curr_Figure.kodi.ToLower())
            {
                case "p":
                    Find_Moves_Paiki(par_visi_poziciidan);
                    break;
                case "r":
                    Find_Moves_Etli(8, par_visi_poziciidan);
                    break;
                case "k":
                    Find_Moves_Mxedari(par_visi_poziciidan);
                    break;
                case "b":
                    Find_Moves_Oficeri(8, par_visi_poziciidan);
                    break;
                case "q":
                    Find_Moves_Dedofali(par_visi_poziciidan);
                    break;
                case "a":
                    Find_Moves_Mefe(par_visi_poziciidan);
                    break;
                default:
                    break;
            }


        }

        int Get_Board_Index(int x, int y)
        {
            return y * 8 + x;
        }

        void fiqtiuri_svlis_gaketeba()
        {


            // პაიკის მიერ პაიკის გავლით აყვანა   
            if (Curr_Figure.kodi.ToLower() == "p")
            {
                if (Board_Array_potenciuri_gavlit_mosaklavi_paiki.Count > 0)
                {
                    if (Board_Array_potenciuri_gavlit_mosaklavi_paiki.ToList().IndexOf(Next_Figure.X) > 0)
                    {
                        ujris_gatavisufleba(Next_Figure.X, Next_Figure.Y + 1);
                    }
                }
            }


            ujraze_mimdinare_figuris_dasma(Next_Figure.X, Next_Figure.Y);
            ujris_gatavisufleba(Curr_Figure.X, Curr_Figure.Y);



        }

        void svlis_gaketeba_Player()
        {

            if (Board_Array_potenciuri_svlebi.ToList().IndexOf(Next_Figure.X + "" + Next_Figure.Y) > -1 || Replay_Mode)
            {
                if (Next_Figure.kodi != "e")
                {
                    Board_Array_moklulebi_Opposite_Color.Add(Next_Figure.kodi.ToLower());
                    paint_moklulebi();
                }
                else
                {
                    // პაიკის მიერ პაიკის გავლით აყვანა   
                    if (Curr_Figure.kodi.ToLower() == "p")
                    {
                        if (Board_Array_potenciuri_gavlit_mosaklavi_paiki.Count > 0)
                        {
                            if (Board_Array_potenciuri_gavlit_mosaklavi_paiki.ToList().IndexOf(Next_Figure.X) > 0)
                            {
                                ujris_gatavisufleba(Next_Figure.X, Next_Figure.Y + 1);
                                Board_Array_moklulebi_Opposite_Color.Add("p");
                                paint_moklulebi();
                            }
                        }
                    }
                }


                if (Curr_Figure.kodi.ToLower() == "p" && Next_Figure.Y == 0)
                {
                    Select_New_Figure_Mode = true;
                    Select_New_Figure_X = Next_Figure.X;
                    paikis_gayvana(Next_Figure.X, 0);
                }
                else
                {

                    if (Curr_Figure.kodi.ToLower() == "r")
                    {
                        if (Curr_Figure.X == 7 && Curr_Figure.Y == 7)
                        {
                            aqvs_mokle_roqis_ufleba = false;
                        }

                        if (Curr_Figure.X == 0 && Curr_Figure.Y == 7)
                        {
                            aqvs_grdzeli_roqis_ufleba = false;
                        }
                    }

                    if (Curr_Figure.kodi.ToLower() == "a")
                    {

                        if (aqvs_roqis_ufleba)
                        {
                            aqvs_roqis_ufleba = false;

                            // aketebs mokle roqs
                            if (PlayerColor == 1)
                            {
                                if (Curr_Figure.X == 4 && Curr_Figure.Y == 7 && Next_Figure.X == 6 && Next_Figure.Y == 7 && aqvs_mokle_roqis_ufleba)
                                {
                                    Board_Array[Get_Board_Index(5, 7)] = Board_Array[Get_Board_Index(7, 7)];
                                    ujris_gatavisufleba(7, 7);
                                }
                            }
                            else
                            {
                                if (Curr_Figure.X == 3 && Curr_Figure.Y == 7 && Next_Figure.X == 1 && Next_Figure.Y == 7 && aqvs_mokle_roqis_ufleba)
                                {
                                    Board_Array[Get_Board_Index(2, 7)] = Board_Array[Get_Board_Index(0, 7)];
                                    ujris_gatavisufleba(0, 7);
                                }
                            }

                            // aketebs grdzel roqs
                            if (PlayerColor == 1)
                            {
                                if (Curr_Figure.X == 4 && Curr_Figure.Y == 7 && Next_Figure.X == 2 && Next_Figure.Y == 7 && aqvs_grdzeli_roqis_ufleba)
                                {
                                    Board_Array[Get_Board_Index(3, 7)] = Board_Array[Get_Board_Index(0, 7)];
                                    ujris_gatavisufleba(0, 7);
                                }
                            }
                            else
                            {
                                if (Curr_Figure.X == 3 && Curr_Figure.Y == 7 && Next_Figure.X == 5 && Next_Figure.Y == 7 && aqvs_grdzeli_roqis_ufleba)
                                {
                                    Board_Array[Get_Board_Index(4, 7)] = Board_Array[Get_Board_Index(7, 7)];
                                    ujris_gatavisufleba(7, 7);
                                }
                            }

                        }
                    }
                    ujraze_mimdinare_figuris_dasma(Next_Figure.X, Next_Figure.Y);

                    string svla = svlis_chawera("");
                    ujris_gatavisufleba(Curr_Figure.X, Curr_Figure.Y);
                    
                    Clear_Curr_And_Next_Figures();


                    aris_mati_an_pati(OppositeColor);

                    Current_Move = OppositeColor;
                    compSettings.rects_list = new List<rect>();

                    compSettings.Curr_comp.NotifyMadeMove(svla);

                   
                   
                }


            }
        }

        void paikis_gayvana(int x, int selected_index)
        {
            //paint_Board();
            //context_Board.fillStyle = "lightyellow";

            //context_Board.fillRect(x * MyCell.width + MyCell.width / 2, MyCell.height / 2, MyCell.width, MyCell.height * 4);

            //context_Board.strokeStyle = MyColors.paikis_gayvanis_charcho;
            //context_Board.lineWidth = MylineWidths.paikis_gayvanis_charcho;
            //context_Board.strokeRect(x * MyCell.width + MyCell.width / 2, MyCell.height / 2, MyCell.width, MyCell.height * 4);


            //context_Board.drawImage(game_Images[PlayerColor.ToString() + "Q"], x * MyCell.width + MyCell.width / 2, 0 * MyCell.height + MyCell.height / 2, MyCell.width, MyCell.height);
            //context_Board.drawImage(game_Images[PlayerColor.ToString() + "R"], x * MyCell.width + MyCell.width / 2, 1 * MyCell.height + MyCell.height / 2, MyCell.width, MyCell.height);
            //context_Board.drawImage(game_Images[PlayerColor.ToString() + "B"], x * MyCell.width + MyCell.width / 2, 2 * MyCell.height + MyCell.height / 2, MyCell.width, MyCell.height);
            //context_Board.drawImage(game_Images[PlayerColor.ToString() + "K"], x * MyCell.width + MyCell.width / 2, 3 * MyCell.height + MyCell.height / 2, MyCell.width, MyCell.height);

            //context_Board.strokeStyle = MyColors.paikis_gayvanis_monishvna;
            //context_Board.lineWidth = MylineWidths.paikis_gayvanis_monishvna;
            //context_Board.strokeRect(x * MyCell.width + MyCell.width / 2 + MylineWidths.paikis_gayvanis_monishvna, selected_index * MyCell.height + MyCell.height / 2 + MylineWidths.paikis_gayvanis_monishvna, MyCell.width - MylineWidths.paikis_gayvanis_monishvna * 2, MyCell.height - MylineWidths.paikis_gayvanis_monishvna * 2);

        }


        void svlis_gaketeba_Opposite()
        {

            if (Next_Figure.kodi != "e")
            {
                Board_Array_moklulebi_Player_Color.Add(Next_Figure.kodi.ToLower());
                paint_moklulebi();
            }
            else
            {
                // პაიკის მიერ პაიკის გავლით აყვანა   
                // if (Curr_Figure.figuris_kodi == 3) {
                //     if (Board_Array_potenciuri_gavlit_mosaklavi_paiki.length > 0) {
                //         if (Board_Array_potenciuri_gavlit_mosaklavi_paiki.ToList().IndexOf(x) > 0) {
                //             ujris_gatavisufleba(x, y + 1);
                //             Board_Array_moklulebi_Opposite_Color.push(3);
                //             paint_moklulebi();
                //         }
                //     }
                // }
            }

            ujraze_mimdinare_figuris_dasma(Next_Figure.X, Next_Figure.Y);
            ujris_gatavisufleba(Curr_Figure.X, Curr_Figure.Y);

            svlis_chawera("");

            Clear_Curr_And_Next_Figures();

           


            aris_mati_an_pati(PlayerColor);

            Current_Move = PlayerColor;
            compSettings.rects_list = new List<rect>();

        }




        string ujris_misamarti(int x, int y)
        {
            return Board_Array_Letters[x] + (8 - y);

        }

        public void svlis_gaketeba_misamartidan(string par_code, int par_vin_aketebs_svlas)
        {

            string sawyisi = par_code.Substring(0, 2);

            Clear_Curr_And_Next_Figures();

            Curr_Figure.isDefined = true;
            Curr_Figure.X = Board_Array_Letters.ToList().IndexOf(sawyisi.Substring(0, 1));
            Curr_Figure.Y = 8 - int.Parse(sawyisi.Substring(1, 1));
            Curr_Figure.index = Get_Board_Index(Curr_Figure.X, Curr_Figure.Y);
            Curr_Figure.kodi = Board_Array[Curr_Figure.index].ToString();


            string saboloo = par_code.Substring(2, 2);

            Next_Figure.isDefined = true;
            Next_Figure.X = Board_Array_Letters.ToList().IndexOf(saboloo.Substring(0, 1));
            Next_Figure.Y = 8 - int.Parse(saboloo.Substring(1, 1));
            Next_Figure.index = Get_Board_Index(Next_Figure.X, Next_Figure.Y);
            Next_Figure.kodi = Board_Array[Next_Figure.index].ToString();


            if (par_vin_aketebs_svlas == PlayerColor)
            {
                svlis_gaketeba_Player();
            }
            else
            {
                svlis_gaketeba_Opposite();
            }
        }

        void ujraze_mimdinare_figuris_dasma(int x, int y)
        {
            Board_Array[Get_Board_Index(x, y)] = Curr_Figure.kodi;
        }


        void ujraze_figuris_dasma(int x, int y, string figuris_kodi)
        {
            Board_Array[Get_Board_Index(x, y)] = figuris_kodi;
        }

        void ujris_gatavisufleba(int x, int y)
        {
            Board_Array[Get_Board_Index(x, y)] = "e";
        }

        int koordinatis_Semowmeba(int Par_X, int Par_Y, int par_visi_poziciidan)
        {
            int result = 0;

            if (Par_Y < 0) return result;
            if (Par_Y > 7) return result;
            if (Par_X < 0) return result;
            if (Par_X > 7) return result;

            // 1 - დააბრუნოს თუ უჯრა თავისუფალია
            // 2 - დააბრუნოს თუ უჯრაზე დგას მისი ფიგურა
            // 3 - დააბრუნოს თუ უჯრაზე დგას მოწინააღმდეგის ფიგურა
            // 4 - დააბრუნოს თუ უჯრაზე დგას მოწინააღმდეგის მეფე

            string Code = Board_Array[Get_Board_Index(Par_X, Par_Y)];

            if (Code == "e") //ე.ი. ცარიელია
            {
                result = 1;
            }
            else
            {
                if (is_my_figure(Code, par_visi_poziciidan)) //ე.ი. მისიანი დევს
                {
                    result = 2;
                }
                else  //ე.ი. მოწინააღმდეგე დევს
                {
                    if (Code.ToLower() == "a") // ე.ი მოწინააღმდეგის მეფეა და მოკვლა არ შეიძლება
                    {
                        result = 4;
                    }
                    else
                    {
                        result = 3;
                    }
                }
            }

            return result;
        }

        void Find_Moves_Paiki(int par_visi_poziciidan)
        {
            int tmp_result = 0;

            // უნდა ვნახოთ უშლის თუ არა ხელს რამე წინ წასვლაში
            tmp_result = koordinatis_Semowmeba(Curr_Figure.X, Curr_Figure.Y - 1, par_visi_poziciidan);

            if (tmp_result == 1)
            {
                ujris_anteba(Curr_Figure.X, Curr_Figure.Y - 1, par_visi_poziciidan);

                // უნდა ვნახოთ 2-ის უფლება თუ აქვს
                if (Curr_Figure.Y == 6) //ე.ი. საწყის პოზიციაზეა
                {
                    tmp_result = koordinatis_Semowmeba(Curr_Figure.X, Curr_Figure.Y - 2, par_visi_poziciidan);
                    if (tmp_result == 1) //ე.ი. ცარიელია
                    {
                        ujris_anteba(Curr_Figure.X, Curr_Figure.Y - 2, par_visi_poziciidan);
                    }
                }
            }

            // უნდა ვნახოთ მოსაკლავი თუ აქვს რამე გვერდებზე

            tmp_result = koordinatis_Semowmeba(Curr_Figure.X + 1, Curr_Figure.Y - 1, par_visi_poziciidan);

            if (tmp_result == 3)
            {
                ujris_anteba(Curr_Figure.X + 1, Curr_Figure.Y - 1, par_visi_poziciidan);
            }

            tmp_result = koordinatis_Semowmeba(Curr_Figure.X - 1, Curr_Figure.Y - 1, par_visi_poziciidan);
            if (tmp_result == 3)
            {
                ujris_anteba(Curr_Figure.X - 1, Curr_Figure.Y - 1, par_visi_poziciidan);
            }

            // ჩაჭრა არის დასამუშავებელი 
            // UC  არაა საკმარისი ეს კოდი შეიძლება პაიკი თითო სვლით არის ამონაწევი და ამ დროს უფლება აღარ აქვს, მოსაფიქრებელია რამე
            if ((Curr_Figure.Y) == 3)
            {

                if (Curr_Figure.X < 7)  // ე.ი. არ დგას მარჯვენა კუთხეში
                {

                    int marjvena_ori_wina_chawra = koordinatis_Semowmeba(Curr_Figure.X + 1, Curr_Figure.Y - 2, par_visi_poziciidan);
                    if (marjvena_ori_wina_chawra == 1) //ე.ი. ცარიელია
                    {
                        int marjvena_wina_chawra = koordinatis_Semowmeba(Curr_Figure.X + 1, Curr_Figure.Y - 1, par_visi_poziciidan);
                        if (marjvena_wina_chawra == 1) //ე.ი. ცარიელია
                        {
                            string marjvena_mezoblis_kodi = Board_Array[Get_Board_Index(Curr_Figure.X + 1, Curr_Figure.Y)];
                            if (marjvena_mezoblis_kodi != "e") //ე.ი. ცარიელი არაა
                            {

                                if (!is_my_figure(marjvena_mezoblis_kodi, par_visi_poziciidan) && marjvena_mezoblis_kodi.ToLower() == "p")
                                {

                                    // მეზობელი არის მოწინააღმდეგე და თან პაიკი
                                    Board_Array_potenciuri_gavlit_mosaklavi_paiki.Add(Curr_Figure.X + 1);
                                    ujris_anteba(Curr_Figure.X + 1, Curr_Figure.Y - 1, par_visi_poziciidan);
                                }
                            }
                        }
                    }
                }

                if (Curr_Figure.X > 0)  // ე.ი. არ დგას მარცხენა კუთხეში
                {

                    int marcxena_ori_wina_chawra = koordinatis_Semowmeba(Curr_Figure.X - 1, Curr_Figure.Y - 2, par_visi_poziciidan);
                    if (marcxena_ori_wina_chawra == 1) //ე.ი. ცარიელია
                    {

                        int marcxena_wina_chawra = koordinatis_Semowmeba(Curr_Figure.X - 1, Curr_Figure.Y - 1, par_visi_poziciidan);
                        if (marcxena_wina_chawra == 1) //ე.ი. ცარიელია
                        {

                            string marcxena_mezoblis_kodi = Board_Array[Get_Board_Index(Curr_Figure.X - 1, Curr_Figure.Y)];
                            if (marcxena_mezoblis_kodi != "e") //ე.ი. ცარიელი არაა
                            {

                                if (!is_my_figure(marcxena_mezoblis_kodi, par_visi_poziciidan) && marcxena_mezoblis_kodi.ToLower() == "p")
                                {
                                    // მეზობელი არის მოწინააღმდეგე და თან პაიკი
                                    Board_Array_potenciuri_gavlit_mosaklavi_paiki.Add(Curr_Figure.X - 1);
                                    ujris_anteba(Curr_Figure.X - 1, Curr_Figure.Y - 1, par_visi_poziciidan);
                                }
                            }
                        }
                    }
                }
            }



        }


        void Find_Moves_Etli(int Par_limit, int par_visi_poziciidan)
        {

            int tmp_result = 0;
            // წინა მიმართულების დამუშავება
            for (int i = 1; i < Par_limit; i++)
            {
                tmp_result = koordinatis_Semowmeba(Curr_Figure.X, Curr_Figure.Y - i, par_visi_poziciidan);
                if (tmp_result == 0)
                {
                    //გავიდა დაფის გარეთ;
                    break;
                }
                if (tmp_result == 1)
                {
                    ujris_anteba(Curr_Figure.X, Curr_Figure.Y - i, par_visi_poziciidan);
                }
                else
                {
                    if (tmp_result == 3) //შეხვდა მოწინააღმდეგე
                    {
                        ujris_anteba(Curr_Figure.X, Curr_Figure.Y - i, par_visi_poziciidan);
                    }
                    break;
                }

            }

            // უკანა მიმართულების დამუშავება
            for (int i = 1; i < Par_limit; i++)
            {
                tmp_result = koordinatis_Semowmeba(Curr_Figure.X, Curr_Figure.Y + i, par_visi_poziciidan);
                if (tmp_result == 0)
                {
                    //გავიდა დაფის გარეთ;
                    break;
                }
                if (tmp_result == 1)
                {
                    ujris_anteba(Curr_Figure.X, Curr_Figure.Y + i, par_visi_poziciidan);
                }
                else
                {
                    if (tmp_result == 3) //შეხვდა მოწინააღმდეგე
                    {
                        ujris_anteba(Curr_Figure.X, Curr_Figure.Y + i, par_visi_poziciidan);
                    }
                    break;
                }

            }

            // მარჯვენა მიმართულების დამუშავება
            for (int i = 1; i < Par_limit; i++)
            {
                tmp_result = koordinatis_Semowmeba(Curr_Figure.X + i, Curr_Figure.Y, par_visi_poziciidan);
                if (tmp_result == 0)
                {
                    //გავიდა დაფის გარეთ;
                    break;
                }
                if (tmp_result == 1)
                {
                    ujris_anteba(Curr_Figure.X + i, Curr_Figure.Y, par_visi_poziciidan);
                }
                else
                {
                    if (tmp_result == 3) //შეხვდა მოწინააღმდეგე
                    {
                        ujris_anteba(Curr_Figure.X + i, Curr_Figure.Y, par_visi_poziciidan);
                    }
                    break;
                }

            }

            // მარცხენა მიმართულების დამუშავება
            for (int i = 1; i < Par_limit; i++)
            {
                tmp_result = koordinatis_Semowmeba(Curr_Figure.X - i, Curr_Figure.Y, par_visi_poziciidan);
                if (tmp_result == 0)
                {
                    //გავიდა დაფის გარეთ;
                    break;
                }
                if (tmp_result == 1)
                {
                    ujris_anteba(Curr_Figure.X - i, Curr_Figure.Y, par_visi_poziciidan);
                }
                else
                {
                    if (tmp_result == 3) //შეხვდა მოწინააღმდეგე
                    {
                        ujris_anteba(Curr_Figure.X - i, Curr_Figure.Y, par_visi_poziciidan);
                    }
                    break;
                }

            }
        }


        void Find_Moves_Mxedari(int par_visi_poziciidan)
        {
            int tmp_result = 0;

            // წინა მარჯვენა გრძელი მიმართულების დამუშავება
            tmp_result = koordinatis_Semowmeba(Curr_Figure.X + 1, Curr_Figure.Y - 2, par_visi_poziciidan);
            if (tmp_result == 1 || tmp_result == 3)
            {
                ujris_anteba(Curr_Figure.X + 1, Curr_Figure.Y - 2, par_visi_poziciidan);
            }

            // წინა მარჯვენა მოკლე მიმართულების დამუშავება
            tmp_result = koordinatis_Semowmeba(Curr_Figure.X + 2, Curr_Figure.Y - 1, par_visi_poziciidan);
            if (tmp_result == 1 || tmp_result == 3)
            {
                ujris_anteba(Curr_Figure.X + 2, Curr_Figure.Y - 1, par_visi_poziciidan);
            }

            // უკანა მარჯვენა გრძელი მიმართულების დამუშავება
            tmp_result = koordinatis_Semowmeba(Curr_Figure.X + 2, Curr_Figure.Y + 1, par_visi_poziciidan);
            if (tmp_result == 1 || tmp_result == 3)
            {
                ujris_anteba(Curr_Figure.X + 2, Curr_Figure.Y + 1, par_visi_poziciidan);
            }

            // უკანა მარჯვენა მოკლე მიმართულების დამუშავება
            tmp_result = koordinatis_Semowmeba(Curr_Figure.X + 1, Curr_Figure.Y + 2, par_visi_poziciidan);
            if (tmp_result == 1 || tmp_result == 3)
            {
                ujris_anteba(Curr_Figure.X + 1, Curr_Figure.Y + 2, par_visi_poziciidan);
            }

            // უკანა მარცხენა გრძელი მიმართულება
            tmp_result = koordinatis_Semowmeba(Curr_Figure.X - 1, Curr_Figure.Y + 2, par_visi_poziciidan);
            if (tmp_result == 1 || tmp_result == 3)
            {
                ujris_anteba(Curr_Figure.X - 1, Curr_Figure.Y + 2, par_visi_poziciidan);
            }

            // უკანა მარცხენა მოკლე მიმართულება
            tmp_result = koordinatis_Semowmeba(Curr_Figure.X - 2, Curr_Figure.Y + 1, par_visi_poziciidan);
            if (tmp_result == 1 || tmp_result == 3)
            {
                ujris_anteba(Curr_Figure.X - 2, Curr_Figure.Y + 1, par_visi_poziciidan);
            }

            // წინა მარცხენა გრძელი მიმართულება
            tmp_result = koordinatis_Semowmeba(Curr_Figure.X - 1, Curr_Figure.Y - 2, par_visi_poziciidan);
            if (tmp_result == 1 || tmp_result == 3)
            {
                ujris_anteba(Curr_Figure.X - 1, Curr_Figure.Y - 2, par_visi_poziciidan);
            }

            // წინა მარცხენა მოკლე მიმართულება
            tmp_result = koordinatis_Semowmeba(Curr_Figure.X - 2, Curr_Figure.Y - 1, par_visi_poziciidan);
            if (tmp_result == 1 || tmp_result == 3)
            {
                ujris_anteba(Curr_Figure.X - 2, Curr_Figure.Y - 1, par_visi_poziciidan);
            }

        }

        void Find_Moves_Oficeri(int Par_limit, int par_visi_poziciidan)
        {

            int tmp_result = 0;
            // მარჯვენა ზედა მიმართულება
            for (int i = 1; i < Par_limit; i++)
            {
                tmp_result = koordinatis_Semowmeba(Curr_Figure.X + i, Curr_Figure.Y - i, par_visi_poziciidan);
                if (tmp_result == 0)
                {
                    //გავიდა დაფის გარეთ;
                    break;
                }
                if (tmp_result == 1)
                {
                    ujris_anteba(Curr_Figure.X + i, Curr_Figure.Y - i, par_visi_poziciidan);
                }
                else
                {
                    if (tmp_result == 3) //შეხვდა მოწინააღმდეგე
                    {
                        ujris_anteba(Curr_Figure.X + i, Curr_Figure.Y - i, par_visi_poziciidan);
                    }
                    break;
                }
            }


            // მარჯვენა ქვედა მიმართულება
            for (int i = 1; i < Par_limit; i++)
            {
                tmp_result = koordinatis_Semowmeba(Curr_Figure.X + i, Curr_Figure.Y + i, par_visi_poziciidan);
                if (tmp_result == 0)
                {
                    //გავიდა დაფის გარეთ;
                    break;
                }
                if (tmp_result == 1)
                {
                    ujris_anteba(Curr_Figure.X + i, Curr_Figure.Y + i, par_visi_poziciidan);
                }
                else
                {
                    if (tmp_result == 3) //შეხვდა მოწინააღმდეგე
                    {
                        ujris_anteba(Curr_Figure.X + i, Curr_Figure.Y + i, par_visi_poziciidan);
                    }
                    break;
                }
            }

            // მარცხენა ზედა მიმართულება
            for (int i = 1; i < Par_limit; i++)
            {
                tmp_result = koordinatis_Semowmeba(Curr_Figure.X - i, Curr_Figure.Y - i, par_visi_poziciidan);
                if (tmp_result == 0)
                {
                    //გავიდა დაფის გარეთ;
                    break;
                }
                if (tmp_result == 1)
                {
                    ujris_anteba(Curr_Figure.X - i, Curr_Figure.Y - i, par_visi_poziciidan);
                }
                else
                {
                    if (tmp_result == 3) //შეხვდა მოწინააღმდეგე
                    {
                        ujris_anteba(Curr_Figure.X - i, Curr_Figure.Y - i, par_visi_poziciidan);
                    }
                    break;
                }
            }

            // მარცხენა ქვედა მიმართულება
            for (int i = 1; i < Par_limit; i++)
            {
                tmp_result = koordinatis_Semowmeba(Curr_Figure.X - i, Curr_Figure.Y + i, par_visi_poziciidan);
                if (tmp_result == 0)
                {
                    //გავიდა დაფის გარეთ;
                    break;
                }
                if (tmp_result == 1)
                {
                    ujris_anteba(Curr_Figure.X - i, Curr_Figure.Y + i, par_visi_poziciidan);
                }
                else
                {
                    if (tmp_result == 3) //შეხვდა მოწინააღმდეგე
                    {
                        ujris_anteba(Curr_Figure.X - i, Curr_Figure.Y + i, par_visi_poziciidan);
                    }
                    break;
                }
            }
        }

        void Find_Moves_Dedofali(int par_visi_poziciidan)
        {
            Find_Moves_Etli(8, par_visi_poziciidan);
            Find_Moves_Oficeri(8, par_visi_poziciidan);
        }

        void Find_Moves_Mefe(int par_visi_poziciidan)
        {

            Find_Moves_Etli(2, par_visi_poziciidan);
            Find_Moves_Oficeri(2, par_visi_poziciidan);

            int tmp_result = 0;
            bool tmp_aris_muqaris_qvesh = false;

            tmp_aris_muqaris_qvesh = ujra_aris_tu_ara_muqaris_qvesh(Curr_Figure.X, Curr_Figure.Y, par_visi_poziciidan);

            if (tmp_aris_muqaris_qvesh == false)
            {
                if (aqvs_roqis_ufleba)
                {
                    // mokle roqi
                    if (aqvs_mokle_roqis_ufleba)
                    {


                        if (PlayerColor == 1)
                        {
                            tmp_result = koordinatis_Semowmeba(Curr_Figure.X + 1, Curr_Figure.Y, PlayerColor);
                            tmp_aris_muqaris_qvesh = ujra_aris_tu_ara_muqaris_qvesh(Curr_Figure.X + 1, Curr_Figure.Y, PlayerColor);
                            if (tmp_result == 1 && tmp_aris_muqaris_qvesh == false)
                            {
                                tmp_result = koordinatis_Semowmeba(Curr_Figure.X + 2, Curr_Figure.Y, PlayerColor);
                                tmp_aris_muqaris_qvesh = ujra_aris_tu_ara_muqaris_qvesh(Curr_Figure.X + 2, Curr_Figure.Y, PlayerColor);
                                if (tmp_result == 1 && tmp_aris_muqaris_qvesh == false)
                                {
                                    string etlis_ujra = Board_Array[Get_Board_Index(Curr_Figure.X + 3, Curr_Figure.Y)];
                                    if (etlis_ujra != "e")
                                    {
                                        if (etlis_ujra.ToLower() == "r")
                                        {
                                            ujris_anteba(Curr_Figure.X + 2, Curr_Figure.Y, par_visi_poziciidan);
                                        }
                                    }
                                }

                            }
                        }
                        else
                        {
                            tmp_result = koordinatis_Semowmeba(Curr_Figure.X - 1, Curr_Figure.Y, PlayerColor);
                            tmp_aris_muqaris_qvesh = ujra_aris_tu_ara_muqaris_qvesh(Curr_Figure.X - 1, Curr_Figure.Y, PlayerColor);
                            if (tmp_result == 1 && tmp_aris_muqaris_qvesh == false)
                            {
                                tmp_result = koordinatis_Semowmeba(Curr_Figure.X - 2, Curr_Figure.Y, PlayerColor);
                                tmp_aris_muqaris_qvesh = ujra_aris_tu_ara_muqaris_qvesh(Curr_Figure.X - 2, Curr_Figure.Y, PlayerColor);
                                if (tmp_result == 1 && tmp_aris_muqaris_qvesh == false)
                                {
                                    string etlis_ujra = Board_Array[Get_Board_Index(Curr_Figure.X - 3, Curr_Figure.Y)].ToString();
                                    if (etlis_ujra != "e")
                                    {
                                        if (etlis_ujra.ToLower() == "r")
                                        {
                                            ujris_anteba(Curr_Figure.X - 2, Curr_Figure.Y, par_visi_poziciidan);
                                        }
                                    }
                                }

                            }
                        }
                    }

                    // grdzeli roqi
                    if (aqvs_grdzeli_roqis_ufleba)
                    {
                        if (PlayerColor == 1)
                        {
                            tmp_result = koordinatis_Semowmeba(Curr_Figure.X - 1, Curr_Figure.Y, PlayerColor);
                            tmp_aris_muqaris_qvesh = ujra_aris_tu_ara_muqaris_qvesh(Curr_Figure.X - 1, Curr_Figure.Y, PlayerColor);
                            if (tmp_result == 1 && tmp_aris_muqaris_qvesh == false)
                            {
                                tmp_result = koordinatis_Semowmeba(Curr_Figure.X - 2, Curr_Figure.Y, PlayerColor);
                                tmp_aris_muqaris_qvesh = ujra_aris_tu_ara_muqaris_qvesh(Curr_Figure.X - 2, Curr_Figure.Y, PlayerColor);
                                if (tmp_result == 1 && tmp_aris_muqaris_qvesh == false)
                                {
                                    tmp_result = koordinatis_Semowmeba(Curr_Figure.X - 3, Curr_Figure.Y, PlayerColor);
                                    tmp_aris_muqaris_qvesh = ujra_aris_tu_ara_muqaris_qvesh(Curr_Figure.X - 3, Curr_Figure.Y, PlayerColor);
                                    if (tmp_result == 1 && tmp_aris_muqaris_qvesh == false)
                                    {
                                        string etlis_ujra = Board_Array[Get_Board_Index(Curr_Figure.X - 4, Curr_Figure.Y)].ToString();

                                        if (etlis_ujra != "e")
                                        {
                                            if (etlis_ujra.ToLower() == "r")
                                            {
                                                ujris_anteba(Curr_Figure.X - 2, Curr_Figure.Y, par_visi_poziciidan);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            tmp_result = koordinatis_Semowmeba(Curr_Figure.X + 1, Curr_Figure.Y, PlayerColor);
                            tmp_aris_muqaris_qvesh = ujra_aris_tu_ara_muqaris_qvesh(Curr_Figure.X + 1, Curr_Figure.Y, PlayerColor);
                            if (tmp_result == 1 && tmp_aris_muqaris_qvesh == false)
                            {
                                tmp_result = koordinatis_Semowmeba(Curr_Figure.X + 2, Curr_Figure.Y, PlayerColor);
                                tmp_aris_muqaris_qvesh = ujra_aris_tu_ara_muqaris_qvesh(Curr_Figure.X + 2, Curr_Figure.Y, PlayerColor);
                                if (tmp_result == 1 && tmp_aris_muqaris_qvesh == false)
                                {
                                    tmp_result = koordinatis_Semowmeba(Curr_Figure.X + 3, Curr_Figure.Y, PlayerColor);
                                    tmp_aris_muqaris_qvesh = ujra_aris_tu_ara_muqaris_qvesh(Curr_Figure.X + 3, Curr_Figure.Y, PlayerColor);
                                    if (tmp_result == 1 && tmp_aris_muqaris_qvesh == false)
                                    {
                                        string etlis_ujra = Board_Array[Get_Board_Index(Curr_Figure.X + 4, Curr_Figure.Y)].ToString();

                                        if (etlis_ujra != "e")
                                        {
                                            if (etlis_ujra.ToLower() == "r")
                                            {
                                                ujris_anteba(Curr_Figure.X + 2, Curr_Figure.Y, par_visi_poziciidan);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        void paint_moklulebi()
        {

            // არ წაშალო, შეიძლება მოკლულების ბადე საჭირო იყოს!!!!!!!!!!!!!!!!

            // let row_index = 0;
            // let column_index = 0;

            // for (let index = 0; index < 32; index++) {

            //     if (index > 7) {
            //         column_index = (index) % 8;
            //         row_index = (index - column_index) / 8;
            //     }
            //     else {
            //         column_index = index;
            //         row_index = 0;
            //     }

            //     if ((index + row_index) % 2 == 0) {
            //         context_moklulebi.fillStyle = MyCell_Moklulebi.white_color;
            //     }
            //     else {
            //         context_moklulebi.fillStyle = MyCell_Moklulebi.black_color;
            //     }

            //     context_moklulebi.fillRect(MyCell_Moklulebi.width * column_index, MyCell_Moklulebi.height * row_index, MyCell_Moklulebi.width, MyCell_Moklulebi.height);
            // }

            int paikebis_raodenoba = 0;
            int etlebis_raodenoba = 0;
            int mxedrebis_raodenoba = 0;
            int oficrebis_raodenoba = 0;
            string kodi = "";

            

            foreach (string i in Board_Array_moklulebi_Opposite_Color)
            {

                kodi = i.ToUpper();

                switch (kodi)
                {
                    case "P":
                        Add_Killed_Figure(OppositeColor + "" + kodi, paikebis_raodenoba * MyCell_Moklulebi.width + MyCell_Moklulebi.width * 0.2, MyCell_Moklulebi.height * 0.2, MyCell_Moklulebi.width, MyCell_Moklulebi.height);
                        paikebis_raodenoba++;
                        break;
                    case "R":
                        if (etlebis_raodenoba == 0)
                        {
                            Add_Killed_Figure(OppositeColor + "" + kodi, MyCell_Moklulebi.width * 0.2, 1.2 * MyCell_Moklulebi.height, MyCell_Moklulebi.width, MyCell_Moklulebi.height);
                        }
                        else
                        {
                            Add_Killed_Figure(OppositeColor + "" + kodi, 7.2 * MyCell_Moklulebi.width, 1.2 * MyCell_Moklulebi.height, MyCell_Moklulebi.width, MyCell_Moklulebi.height);
                        }
                        etlebis_raodenoba++;
                        break;
                    case "K":
                        if (mxedrebis_raodenoba == 0)
                        {
                            Add_Killed_Figure(OppositeColor + "" + kodi, 1.2 * MyCell_Moklulebi.width, 1.2 * MyCell_Moklulebi.height, MyCell_Moklulebi.width, MyCell_Moklulebi.height);
                        }
                        else
                        {
                            Add_Killed_Figure(OppositeColor + "" + kodi, 6.2 * MyCell_Moklulebi.width, 1.2 * MyCell_Moklulebi.height, MyCell_Moklulebi.width, MyCell_Moklulebi.height);
                        }
                        mxedrebis_raodenoba++;
                        break;
                    case "B":
                        if (oficrebis_raodenoba == 0)
                        {
                            Add_Killed_Figure(OppositeColor + "" + kodi, 2.2 * MyCell_Moklulebi.width, 1.2 * MyCell_Moklulebi.height, MyCell_Moklulebi.width, MyCell_Moklulebi.height);
                        }
                        else
                        {
                            Add_Killed_Figure(OppositeColor + "" + kodi, 5.2 * MyCell_Moklulebi.width, 1.2 * MyCell_Moklulebi.height, MyCell_Moklulebi.width, MyCell_Moklulebi.height);
                        }
                        oficrebis_raodenoba++;
                        break;
                    case "Q":
                        Add_Killed_Figure(OppositeColor + "" + kodi, 3.2 * MyCell_Moklulebi.width, 1.2 * MyCell_Moklulebi.height, MyCell_Moklulebi.width, MyCell_Moklulebi.height);
                        break;
                    default:
                        break;
                }

            }


            paikebis_raodenoba = 0;
            etlebis_raodenoba = 0;
            mxedrebis_raodenoba = 0;
            oficrebis_raodenoba = 0;
            kodi = "";

            foreach (string i in Board_Array_moklulebi_Player_Color)
            {
                kodi = i.ToUpper();
                switch (kodi)
                {
                    case "P":
                        Add_Killed_Figure(PlayerColor + "" + kodi, paikebis_raodenoba * MyCell_Moklulebi.width + MyCell_Moklulebi.width * 0.2, 2.2 * MyCell_Moklulebi.height, MyCell_Moklulebi.width, MyCell_Moklulebi.height);
                        paikebis_raodenoba++;
                        break;
                    case "R":
                        if (etlebis_raodenoba == 0)
                        {
                            Add_Killed_Figure(PlayerColor + "" + kodi, MyCell_Moklulebi.width * 0.2, 3.2 * MyCell_Moklulebi.height, MyCell_Moklulebi.width, MyCell_Moklulebi.height);
                        }
                        else
                        {
                            Add_Killed_Figure(PlayerColor + "" + kodi, 7.2 * MyCell_Moklulebi.width, 3.2 * MyCell_Moklulebi.height, MyCell_Moklulebi.width, MyCell_Moklulebi.height);
                        }
                        etlebis_raodenoba++;
                        break;
                    case "K":
                        if (mxedrebis_raodenoba == 0)
                        {
                            Add_Killed_Figure(PlayerColor + "" + kodi, 1.2 * MyCell_Moklulebi.width, 3.2 * MyCell_Moklulebi.height, MyCell_Moklulebi.width, MyCell_Moklulebi.height);
                        }
                        else
                        {
                            Add_Killed_Figure(PlayerColor + "" + kodi, 6.2 * MyCell_Moklulebi.width, 3.2 * MyCell_Moklulebi.height, MyCell_Moklulebi.width, MyCell_Moklulebi.height);
                        }
                        mxedrebis_raodenoba++;
                        break;
                    case "B":
                        if (oficrebis_raodenoba == 0)
                        {
                            Add_Killed_Figure(PlayerColor + "" + kodi, 2.2 * MyCell_Moklulebi.width, 3.2 * MyCell_Moklulebi.height, MyCell_Moklulebi.width, MyCell_Moklulebi.height);
                        }
                        else
                        {
                            Add_Killed_Figure(PlayerColor + "" + kodi, 5.2 * MyCell_Moklulebi.width, 3.2 * MyCell_Moklulebi.height, MyCell_Moklulebi.width, MyCell_Moklulebi.height);
                        }
                        oficrebis_raodenoba++;
                        break;
                    case "Q":
                        Add_Killed_Figure(PlayerColor + "" + kodi, 3.2 * MyCell_Moklulebi.width, 3.2 * MyCell_Moklulebi.height, MyCell_Moklulebi.width, MyCell_Moklulebi.height);
                        break;
                    default:
                        break;
                }

            }

            compSettings.Curr_Comp_Stat.Refresh();


        }


        void Add_Killed_Figure(string _img, double _x, double _y, double _w, double _h)
        {
            compSettings.KilledFigures_list.Add(new image
            {
                x = _x,
                y = _y,
                width = _w,
                height = _h,
                href = "content/images/style3/" + _img + ".png",
                onclick = BoolOptionsEnum.Yes,
            });
        }

        string svlis_chawera(string par_Extra)
        {


            string sawyisi_misamarti = ujris_misamarti(Curr_Figure.X, Curr_Figure.Y);

            string saboloo_misamarti = ujris_misamarti(Next_Figure.X, Next_Figure.Y);

            
            if (Current_Move == 1)
            {
                compSettings.Moves_list.Add("white - " + sawyisi_misamarti + " - " + saboloo_misamarti + par_Extra);
         
            }
            else
            {
                compSettings.Moves_list.Add("black - " + sawyisi_misamarti + " - " + saboloo_misamarti + par_Extra);
  
            }

            compSettings.Curr_comp.Refresh();


            return sawyisi_misamarti + saboloo_misamarti;
        }





        public void Cmd_Replay()
        {

            if (timer_Game != null)
            {
                timer_Game.Dispose();
            }

           
            timer_Replay = new Timer(TimerReplayCallback, null, 0, 1000);

        }

        void TimerReplayCallback(Object stateInfo)
        {

            if (Curr_Replay_Index < Board_Array_Moves.Length)
            {
                svlis_gaketeba_misamartidan(Board_Array_Moves[Curr_Replay_Index], Current_Move);
                Curr_Replay_Index++;
            }
            else
            {
                timer_Replay.Dispose();
                
            }
        }

        string get_figuris_kodi(int x, int y)
        {
            return Board_Array[Get_Board_Index(x, y)];
        }

        string get_relevant_case(string p, int par_visi_poziciidan)
        {

            if (par_visi_poziciidan == 1)
            {
                return p.ToUpper();
            }
            else
            {
                return p.ToLower();
            }


        }

        bool ujra_aris_tu_ara_muqaris_qvesh(int x, int y, int par_visi_poziciidan)
        {



            bool result = false;
            string mownaaRmdegis_figuris_kodi = string.Empty;

            int tmp_result = 0;

            // ზედა ჰორიზონტალური მიმართულების დამუშავება
            for (int i = 1; i < 8; i++)
            {

                tmp_result = koordinatis_Semowmeba(x, y - i, par_visi_poziciidan);
                if (tmp_result == 0 || tmp_result == 2)
                {
                    break;
                }
                else
                {
                    if (tmp_result == 3 || tmp_result == 4)
                    {
                        mownaaRmdegis_figuris_kodi = get_figuris_kodi(x, y - i);
                        if (mownaaRmdegis_figuris_kodi.ToLower() == "a" && i == 1)
                        {
                            return true;
                        }
                        if (mownaaRmdegis_figuris_kodi.ToLower() == "q" || mownaaRmdegis_figuris_kodi.ToLower() == "r")
                        {
                            return true;
                        }
                        break;
                    }
                }
            }


            // ქვედა ჰორიზონტალური მიმართულების დამუშავება
            for (int i = 1; i < 8; i++)
            {
                tmp_result = koordinatis_Semowmeba(x, y + i, par_visi_poziciidan);
                if (tmp_result == 0 || tmp_result == 2)
                {
                    break;
                }
                else
                {
                    if (tmp_result == 3 || tmp_result == 4)
                    {
                        mownaaRmdegis_figuris_kodi = get_figuris_kodi(x, y + i);
                        if (mownaaRmdegis_figuris_kodi.ToLower() == "a" && i == 1)
                        {
                            return true;
                        }

                        if (mownaaRmdegis_figuris_kodi.ToLower() == "q" || mownaaRmdegis_figuris_kodi.ToLower() == "r")
                        {
                            return true;
                        }

                        break;
                    }
                }
            }


            // მარჯვენა ჰორიზონტალური მიმართულების დამუშავება
            for (int i = 1; i < 8; i++)
            {
                tmp_result = koordinatis_Semowmeba(x + i, y, par_visi_poziciidan);
                if (tmp_result == 0 || tmp_result == 2)
                {
                    break;
                }
                else
                {
                    if (tmp_result == 3 || tmp_result == 4)
                    {
                        mownaaRmdegis_figuris_kodi = get_figuris_kodi(x + i, y);
                        if (mownaaRmdegis_figuris_kodi.ToLower() == "a" && i == 1)
                        {
                            return true;
                        }
                        if (mownaaRmdegis_figuris_kodi.ToLower() == "q" || mownaaRmdegis_figuris_kodi.ToLower() == "r")
                        {
                            return true;
                        }

                        break;
                    }
                }
            }


            // მარცხენა ჰორიზონტალური მიმართულების დამუშავება
            for (int i = 1; i < 8; i++)
            {
                tmp_result = koordinatis_Semowmeba(x - i, y, par_visi_poziciidan);

                if (tmp_result == 0 || tmp_result == 2)
                {
                    break;
                }
                else
                {
                    if (tmp_result == 3 || tmp_result == 4)
                    {
                        mownaaRmdegis_figuris_kodi = get_figuris_kodi(x - i, y);
                        if (mownaaRmdegis_figuris_kodi.ToLower() == "a" && i == 1)
                        {
                            return true;
                        }

                        if (mownaaRmdegis_figuris_kodi.ToLower() == "q" || mownaaRmdegis_figuris_kodi.ToLower() == "r")
                        {
                            return true;
                        }

                        break;
                    }
                }
            }


            // მარჯვენა ზედა დიაგონალური მიმართულების დამუშავება
            for (int i = 1; i < 8; i++)
            {
                tmp_result = koordinatis_Semowmeba(x + i, y - i, par_visi_poziciidan);
                if (tmp_result == 0 || tmp_result == 2)
                {
                    break;
                }
                else
                {
                    if (tmp_result == 3 || tmp_result == 4)
                    {
                        mownaaRmdegis_figuris_kodi = get_figuris_kodi(x + i, y - i);
                        if (mownaaRmdegis_figuris_kodi.ToLower() == "a" && i == 1)
                        {
                            return true;
                        }
                        if (mownaaRmdegis_figuris_kodi.ToLower() == "q" || mownaaRmdegis_figuris_kodi.ToLower() == "b")
                        {
                            return true;
                        }

                        if (mownaaRmdegis_figuris_kodi.ToLower() == "p" && i == 1 && par_visi_poziciidan == PlayerColor)
                        {
                            return true;
                        }
                        break;
                    }
                }
            }


            // მარჯვენა ქვედა დიაგონალური მიმართულების დამუშავება
            for (int i = 1; i < 8; i++)
            {
                tmp_result = koordinatis_Semowmeba(x + i, y + i, par_visi_poziciidan);
                if (tmp_result == 0 || tmp_result == 2)
                {
                    break;
                }
                else
                {
                    if (tmp_result == 3 || tmp_result == 4)
                    {
                        mownaaRmdegis_figuris_kodi = get_figuris_kodi(x + i, y + i);
                        if (mownaaRmdegis_figuris_kodi.ToLower() == "a" && i == 1)
                        {
                            return true;
                        }
                        if (mownaaRmdegis_figuris_kodi.ToLower() == "q" || mownaaRmdegis_figuris_kodi.ToLower() == "b")
                        {
                            return true;
                        }

                        if (mownaaRmdegis_figuris_kodi.ToLower() == "p" && i == 1 && par_visi_poziciidan == OppositeColor)
                        {
                            return true;
                        }
                        break;
                    }
                }
            }


            // მარცხენა ზედა დიაგონალური მიმართულების დამუშავება
            for (int i = 1; i < 8; i++)
            {
                tmp_result = koordinatis_Semowmeba(x - i, y - i, par_visi_poziciidan);
                if (tmp_result == 0 || tmp_result == 2)
                {
                    break;
                }
                else
                {
                    if (tmp_result == 3 || tmp_result == 4)
                    {
                        mownaaRmdegis_figuris_kodi = get_figuris_kodi(x - i, y - i);

                        if (mownaaRmdegis_figuris_kodi.ToLower() == "a" && i == 1)
                        {
                            return true;
                        }

                        if (mownaaRmdegis_figuris_kodi.ToLower() == "q" || mownaaRmdegis_figuris_kodi.ToLower() == "b")
                        {
                            return true;
                        }

                        if (mownaaRmdegis_figuris_kodi.ToLower() == "p" && i == 1 && par_visi_poziciidan == PlayerColor)
                        {
                            return true;
                        }

                        break;
                    }
                }
            }

            // მარცხენა ქვედა დიაგონალური მიმართულების დამუშავება
            for (int i = 1; i < 8; i++)
            {
                tmp_result = koordinatis_Semowmeba(x - i, y + i, par_visi_poziciidan);
                if (tmp_result == 0 || tmp_result == 2)
                {
                    break;
                }
                else
                {
                    if (tmp_result == 3 || tmp_result == 4)
                    {
                        mownaaRmdegis_figuris_kodi = get_figuris_kodi(x - i, y + i);

                        if (mownaaRmdegis_figuris_kodi.ToLower() == "a" && i == 1)
                        {
                            return true;
                        }

                        if (mownaaRmdegis_figuris_kodi.ToLower() == "q" || mownaaRmdegis_figuris_kodi.ToLower() == "b")
                        {
                            return true;
                        }

                        if (mownaaRmdegis_figuris_kodi.ToLower() == "p" && i == 1 && par_visi_poziciidan == OppositeColor)
                        {
                            return true;
                        }

                        break;
                    }
                }
            }

            // მხედრის წინა მარჯვენა გრძელი მიმართულების დამუშავება
            tmp_result = koordinatis_Semowmeba(x + 1, y - 2, par_visi_poziciidan);
            if (tmp_result == 3)
            {
                mownaaRmdegis_figuris_kodi = get_figuris_kodi(x + 1, y - 2);

                if (mownaaRmdegis_figuris_kodi.ToLower() == "k")
                {
                    return true;
                }
            }



            // მხედრის წინა მარჯვენა მოკლე მიმართულების დამუშავება
            tmp_result = koordinatis_Semowmeba(x + 2, y - 1, par_visi_poziciidan);
            if (tmp_result == 3)
            {
                mownaaRmdegis_figuris_kodi = get_figuris_kodi(x + 2, y - 1);

                if (mownaaRmdegis_figuris_kodi.ToLower() == "k")
                {
                    return true;
                }
            }

            // მხედრის უკანა მარჯვენა გრძელი მიმართულების დამუშავება
            tmp_result = koordinatis_Semowmeba(x + 2, y + 1, par_visi_poziciidan);
            if (tmp_result == 3)
            {
                mownaaRmdegis_figuris_kodi = get_figuris_kodi(x + 2, y + 1);

                if (mownaaRmdegis_figuris_kodi.ToLower() == "k")
                {
                    return true;
                }
            }


            // მხედრის უკანა მარჯვენა მოკლე მიმართულების დამუშავება
            tmp_result = koordinatis_Semowmeba(x + 1, y + 2, par_visi_poziciidan);
            if (tmp_result == 3)
            {
                mownaaRmdegis_figuris_kodi = get_figuris_kodi(x + 1, y + 2);

                if (mownaaRmdegis_figuris_kodi.ToLower() == "k")
                {
                    return true;
                }
            }


            // მხედრის უკანა მარცხენა გრძელი მიმართულება
            tmp_result = koordinatis_Semowmeba(x - 1, y + 2, par_visi_poziciidan);
            if (tmp_result == 3)
            {
                mownaaRmdegis_figuris_kodi = get_figuris_kodi(x - 1, y + 2);

                if (mownaaRmdegis_figuris_kodi.ToLower() == "k")
                {
                    return true;
                }
            }

            // მხედრის უკანა მარცხენა მოკლე მიმართულება
            tmp_result = koordinatis_Semowmeba(x - 2, y + 1, par_visi_poziciidan);
            if (tmp_result == 3)
            {
                mownaaRmdegis_figuris_kodi = get_figuris_kodi(x - 2, y + 1);

                if (mownaaRmdegis_figuris_kodi.ToLower() == "k")
                {
                    return true;
                }
            }


            // მხედრის წინა მარცხენა გრძელი მიმართულება
            tmp_result = koordinatis_Semowmeba(x - 1, y - 2, par_visi_poziciidan);
            if (tmp_result == 3)
            {
                mownaaRmdegis_figuris_kodi = get_figuris_kodi(x - 1, y - 2);

                if (mownaaRmdegis_figuris_kodi.ToLower() == "k")
                {
                    return true;
                }
            }

            // მხედრის წინა მარცხენა მოკლე მიმართულება
            tmp_result = koordinatis_Semowmeba(x - 2, y - 2, par_visi_poziciidan);
            if (tmp_result == 3)
            {
                mownaaRmdegis_figuris_kodi = get_figuris_kodi(x - 2, y - 2);

                if (mownaaRmdegis_figuris_kodi.ToLower() == "k")
                {
                    return true;
                }
            }


            return result;
        }


        void Reverse_Board()
        {

            string tmp_code = string.Empty;
            for (var index = 0; index < Board_Array.Length / 2; index++)
            {
                tmp_code = Board_Array[index];
                Board_Array[index] = Board_Array[63 - index];
                Board_Array[63 - index] = tmp_code;

            }

            

        }


        void aris_mati_an_pati(int par_vin_waago)
        {
            bool result = true;

            
            bool has_shax = false;

            if (par_vin_waago == PlayerColor)
            {
                has_shax = Player_Has_Shax;
            }
            else
            {
                has_shax = Opposite_Has_Shax;
            }

           

            string King_Letter = "A";

            if (par_vin_waago == OppositeColor)
            {
                King_Letter = King_Letter.ToLower();
            }

            Save_Or_Restore_Curr_Figure(false);

            ar_avantot_ujrebi = true;

            List<string> tmp_Board_Array_potenciuri_svlebi = new List<string>(Board_Array_potenciuri_svlebi);
            List<int> tmp_Board_Array_potenciuri_gavlit_mosaklavi_paiki = new List<int>(Board_Array_potenciuri_gavlit_mosaklavi_paiki);

            Board_Array_potenciuri_svlebi = new List<string>();
            Board_Array_potenciuri_gavlit_mosaklavi_paiki = new List<int>();

            int King_Index = Board_Array.ToList().IndexOf(King_Letter);
            Curr_Figure.isDefined = true;
            Curr_Figure.X = King_Index % 8;
            Curr_Figure.Y = (King_Index - Curr_Figure.X) / 8;
            Curr_Figure.index = King_Index;
            Curr_Figure.kodi = Board_Array[King_Index];
            Find_Moves_Mefe(par_vin_waago);
          
            if (Board_Array_potenciuri_svlebi.Count > 0)
            {
                result = false;
            }
            else
            {
                if (has_Other_Figures(PlayerColor))
                {



                    for (var index = 0; index < Board_Array.Length; index++)
                    {

                        if (is_my_figure(Board_Array[index], par_vin_waago))
                        {
                            if (Board_Array[index].ToLower() != "a")
                            {
                                Curr_Figure.isDefined = true;
                                Curr_Figure.X = index % 8;
                                Curr_Figure.Y = (index - Curr_Figure.X) / 8;
                                Curr_Figure.index = index;
                                Curr_Figure.kodi = Board_Array[index];

                              
                                Find_Moves(par_vin_waago);

                                if (Board_Array_potenciuri_svlebi.Count > 0)
                                {
                                  
                                    result = false;
                                    break;
                                }
                            }
                        }
                    }


                }
                else
                {
                    result = true;
                }

            }

            Board_Array_potenciuri_svlebi = new List<string>(tmp_Board_Array_potenciuri_svlebi);
            Board_Array_potenciuri_gavlit_mosaklavi_paiki = new List<int>(tmp_Board_Array_potenciuri_gavlit_mosaklavi_paiki);

            ar_avantot_ujrebi = false;

            Save_Or_Restore_Curr_Figure(true);








            if (result)
            {

                if (has_shax)
                {
                    Game_Over("mati");
                }
                else
                {
                    Game_Over("pati");
                }


            }

        }


        void Save_Or_Restore_Curr_Figure(bool Save_false_Or_Restore_true)
        {

            if (Save_false_Or_Restore_true)
            {
                Curr_Figure.isDefined = tmp_Figure.isDefined;
                Curr_Figure.X = tmp_Figure.X;
                Curr_Figure.Y = tmp_Figure.Y;
                Curr_Figure.index = tmp_Figure.index;
                Curr_Figure.kodi = tmp_Figure.kodi;

            }
            else
            {
                tmp_Figure.isDefined = Curr_Figure.isDefined;
                tmp_Figure.X = Curr_Figure.X;
                tmp_Figure.Y = Curr_Figure.Y;
                tmp_Figure.index = Curr_Figure.index;
                tmp_Figure.kodi = Curr_Figure.kodi;
            }

        }

        bool has_Other_Figures(int par_PlayerColor)
        {
            bool result = false;

            for (var index = 0; index < All_Figures_Without_King.Length; index++)
            {
                if (par_PlayerColor == 1)
                {
                    if (Board_Array.ToList().IndexOf(All_Figures_Without_King[index].ToString().ToUpper()) > -1)
                    {
                        result = true;
                        break;
                    }
                }
                else
                {
                    if (Board_Array.ToList().IndexOf(All_Figures_Without_King[index].ToString().ToLower()) > -1)
                    {
                        result = true;
                        break;
                    }
                }
            }


            return result;
        }



        private void TimerGameCallback(Object stateInfo)
        {
            Timertick();
        }

        public void Timertick()
        {
            if (Current_Move == PlayerColor)
            {
                if (Player_Total_Seconds > 0)
                {
                    Player_Total_Seconds--;
                    compSettings.Curr_comp.PlayerTime = TimeSpan.FromSeconds(Player_Total_Seconds).ToString(@"mm\:ss");
                }
                else
                {
                    Game_Over("time");
                    compSettings.Curr_comp.NotifyGameOver();
                }
            }
            else
            {
                if (Opposite_Total_Seconds > 0)
                {
                    Opposite_Total_Seconds--;
                    compSettings.Curr_comp.OppositeTime = TimeSpan.FromSeconds(Opposite_Total_Seconds).ToString(@"mm\:ss");  
                }
                else
                {
                    Game_Over("time");
                    compSettings.Curr_comp.NotifyGameOver();
                }
            }

            compSettings.Curr_comp.Refresh();
        }



        public int GetPlayerScore()
        {
            
            int score = 0;

            foreach (string item in Board_Array_moklulebi_Opposite_Color)
            {
                switch (item)
                {
                    case "p":
                        score += 1;
                        break;
                    case "r":
                        score += 5;
                        break;
                    case "b":
                    case "k":
                        score += 3;
                        break;
                    case "q":
                        score += 10;
                        break;
                    default:
                        break;
                }
            }

            return score;
        }


        public int GetOppositeScore()
        {

            int score = 0;

            foreach (string item in Board_Array_moklulebi_Player_Color)
            {
                switch (item)
                {
                    case "p":
                        score += 1;
                        break;
                    case "r":
                        score += 5;
                        break;
                    case "b":
                    case "k":
                        score += 3;
                        break;
                    case "q":
                        score += 10;
                        break;
                    default:
                        break;
                }
            }

            return score;
        }


        [JSInvokable]
        public void invokeFromjs(string id, string x, string y)
        {
            compSettings.BoardPositionX = double.Parse(x);
            compSettings.BoardPositionY = double.Parse(y);
        }

    }
}
