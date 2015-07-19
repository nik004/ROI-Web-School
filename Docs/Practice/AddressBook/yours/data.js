var addressBookJson = (function() {
	var categories = ["Family", "School", "Colleagues", "Other"];
	
	var count = Math.random() * 20 + 5;
	var contacts = [];
	
	function prob(p, func) {
		if(Math.random() < p) {
			return func.apply(chance);
		}
		
		return null;
	}
	
	for(var i = 0; i < count; i++) {
		var contact = {
			name: chance.first(),
			lastName: prob(0.6, chance.last),
			phone: chance.phone({ mobile: true }),
			category: categories[Math.floor(Math.random() * (categories.length))],
			city: prob(0.2, chance.city),
			year: prob(0.6, function() { return chance.year({min: 1920, max: 2014 }); }),
		};
		
		contacts.push(contact);
	}
	
	return {
		contacts: contacts
	};
})();