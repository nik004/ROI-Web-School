document.addEventListener("DOMContentLoaded", function () {
    var validate = document.getElementById("validate");

    validate.onclick = function () {
        var inputs = document.getElementsByTagName("input");
        for (var i = 0; i < inputs.length; i++) {
			var classes = inputs[i].parentNode.className.split(" ");
            if (classes.indexOf("required") > -1) {
				var invalidIndex = classes.indexOf("invalid");
				if (inputs[i].value == "") {
					if(invalidIndex == -1) classes.push("invalid");
                }
				else if(invalidIndex > -1) classes.splice(invalidIndex, 1);
				inputs[i].parentNode.className = classes.join(" ");
            }
        }
    };
}, false);
