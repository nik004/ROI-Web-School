function computedArray(items, converter) {
    var oldValues = [];
    var oldResults = [];

    return ko.computed(function () {
        var values = items().slice();
        var results = [];

        ko.utils.arrayForEach(values, function (item) {
            var index = oldValues.indexOf(item);
            results.push(index > -1 ? oldResults[index]
                                    : converter(item));
        });

        oldValues = values;
        oldResults = results;

        return results;
    });
}

function ContactViewModel(model) {
	var self = this;
	
	self.name = model.name;
	self.phone = model.phone;
	
	self.isSelected = ko.observable(false);
	self.toggleSelected = function() {
		self.isSelected(!self.isSelected());
	};
}

function AddressBookViewModel(model) {
	var self = this;
	
	self.contacts = computedArray(model.contacts, function(contact) {
		return new ContactViewModel(contact);
	});
	
	self.hasSelectedContacts = ko.computed(function() {
		return ko.utils.arrayFirst(self.contacts(), function(item) {
			return item.isSelected();
		});
	});
}

$(function() {
	var model = ko.mapping.fromJS(addressBookJson);
	
	ko.applyBindings(new AddressBookViewModel(model));
});