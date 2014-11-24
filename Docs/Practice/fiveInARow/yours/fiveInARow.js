var fieldWidth  = 32;
var fieldHeight = 32;

function createEmptyRow() {
	var a = [];
	for(var column = 0; column < fieldWidth; column++) {
		a.push(null);
	}
	
	return a;
}

var a = [];
for(var row = 0; row < fieldHeight; row++) {
	a.push(createEmptyRow());
}

document.addEventListener("DOMContentLoaded", function() {
	var gameMenu = document.getElementById("gameMenu");
	gameMenu.parentNode.removeChild(gameMenu);
	
	var field = document.getElementById("field");
	for(var row = 0; row < fieldHeight; row++) {
		var rowElement = document.createElement("div");
		rowElement.className = "row";
		field.appendChild(rowElement);
		
		for(var column = 0; column < fieldWidth; column++) {
			var cell = document.createElement("div");
			cell.className = "cell";
			rowElement.appendChild(cell);
			
			cell.addEventListener("click", function() {
				var classes = this.className.split(" ");
				if(classes.indexOf("x") < 0) {
					classes.push("x");
				}
				
				this.className = classes.join(" ");
			});
		}
	}
	
	document.getElementById("game").className = "";
});
