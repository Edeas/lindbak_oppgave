
function Customer(email, firstName, lastName, address, postalCode, id) {
    var self = this;
    self.email = ko.observable(email);
    self.firstName = ko.observable(firstName);
    self.lastName = ko.observable(lastName);
    self.address = ko.observable(address);
    self.postalCode = ko.observable(postalCode);
    self.id = id;
}

function RegisterViewModel() {
    var self = this;
    self.customers = ko.observableArray();

    self.newEmail = ko.observable();
    self.newFirstName = ko.observable();
    self.newLastName = ko.observable();
    self.newAddress = ko.observable();
    self.newPostalCode = ko.observable();

    $.getJSON("/api/register/getallcustomers", function (data, status) {
        var list = [];
        for (var i in data) {
            var c = data[i];
            list.push(new Customer(c.Email, c.FirstName, c.LastName, c.Address, c.PostalCode, c.Id))
        }
        self.customers(list);
    });

    self.addCustomer = function () {
        var c = new Customer(self.newEmail(), self.newFirstName(), self.newLastName(), self.newAddress(), self.newPostalCode(), -1);
        // Check if fields are empty
        if (c.email() == undefined) return;
        if (c.firstName() == undefined) return;
        if (c.lastName() == undefined) return;
        if (c.address() == undefined) return;
        if (c.postalCode() == undefined) return;
        self.customers.push(c);
        $.post("/api/Register/AddCustomer", c, function (result) { });

        self.newEmail(undefined);
        self.newFirstName(undefined);
        self.newLastName(undefined);
        self.newAddress(undefined);
        self.newPostalCode(undefined);
    };

    self.updateCustomer = function (customer) {
        $.post("/api/Register/UpdateCustomer", customer, function (result) { });

    };

    self.deleteCustomer = function (customer) {
        self.customers.remove(customer);
        $.post("/api/Register/DeleteCustomer", customer, function (result) { });
    };
}
$(document).ready(function(){
    ko.applyBindings(new RegisterViewModel());
});