
window.BApp1JsFunctions = {
    calcfib: function (num) {
        return fib(num);
    },
    generateNewUser: function () {
        return faker.name.findName() + ", " + faker.address.country() + ", Age " + (Math.floor(Math.random() * 50) + 15);
    },

};