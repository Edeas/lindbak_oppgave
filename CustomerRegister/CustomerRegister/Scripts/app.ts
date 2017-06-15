
function Customer(id: number, firstName: string, lastName: string, email: string, address: string, postalCode: string) {
    this.id = id;
    this.firstName = ko.observable(firstName);
    this.lastName = ko.observable(lastName);
    this.email = ko.observable(email);
    this.address = ko.observable(address);
    this.postalCode = ko.observable(postalCode);
}

function RegisterViewModel() {

    this.customers = ko.observableArray();

    $.getJSON("/api/register", function (data, status) {
        var list = [];
        for (var i in data) {
            var c = i;
            list.push(new Customer(c.Id, c.FirstName, c.LastName, c.Email, c.Address, c.PostalCode))
        }
        this.customers(list);
    });
}

ko.applyBindings(new RegisterViewModel());