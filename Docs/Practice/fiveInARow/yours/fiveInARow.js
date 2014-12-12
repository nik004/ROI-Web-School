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

var TypeOfPlayer = "x";
var TimeOfPlayer_x  =0;
var TimeOfPlayer_o  =0;

function GetTextInterval(sec)
{
	var text = "";
	var min = parseInt(sec/60);
	var sec = sec%60;
	(min >= 10) ? (text = text + min + ":") : (text = text + "0" + min + ":") ;
	if (min == 0){(text = "00" + ":")};
	(sec >= 10) ? (text = text + sec) : (text = text + "0" + sec);
	return text;	
}

function update()
{
	var x = document.getElementsByClassName("activ");
	var active_player = x[0];
	x = active_player.getElementsByClassName("time");
	var timer = x[0];
	var classes = active_player.className.split(" ");				
	if  (classes.indexOf("x") < 0) 
	{
		TimeOfPlayer_o -= 1;
		if (TimeOfPlayer_o <= 0) {winner()};
		timer.innerHTML  = GetTextInterval(TimeOfPlayer_o);
	}
	else
	{
		TimeOfPlayer_x -=1;
		if (TimeOfPlayer_x <= 0) {winner()};
		timer.innerHTML  = GetTextInterval(TimeOfPlayer_x);
	}
	
	
}

function InversePlayers()
{
	if (TypeOfPlayer == "x")
	{
		player_x = document.getElementsByClassName("player x");
		var classes = player_x[0].className.split(" ");
		var pos = classes.indexOf ("activ");
		if ( pos >=0)
		{
			classes.splice(pos,1);
			player_x[0].className = classes.join(" ");
		}		
		
		player_o = document.getElementsByClassName("player o");
		player_o[0].className += " activ";
		
		TypeOfPlayer = "o";		
	}
	else
	{
		player_o = document.getElementsByClassName("player o");
		var classes = player_o[0].className.split(" ");
		var pos = classes.indexOf ("activ");
		if ( pos >=0)
		{
			classes.splice(pos,1);
			player_o[0].className = classes.join(" ");
		}		
		
		player_x = document.getElementsByClassName("player x");
		player_x[0].className += " activ";
		
		TypeOfPlayer = "x";
	}
	

}

function CheckWin (id)
{
	
	var mas = id.split("_");
	x = Number(mas[0]);
	y = Number(mas[1]);
	
	left_index = (x-4);
	if (left_index <=0) { left_index = 0};

	right_index = (x+4);
	if (right_index >= fieldWidth) { right_index = fieldWidth};
	
	up_index = (y-4);
	if (up_index <=0) { up_index = 0};

	down_index = (y+4);
	if (down_index >= fieldHeight) { down_index = fieldHeight};
	
	var searchClass;
	(TypeOfPlayer == "x")? ( searchClass = "x") : ( searchClass = "o");
	count = 0;
	var cell;
	for (var i = left_index; i<= right_index; i++)
	{
		cell = document.getElementById("" + i + "_" + y);
		var classes = cell.className.split(" ");
		(classes.indexOf(searchClass) >= 0)?  (count++) : (count = 0) ;
		if (count == 5) 
		{
			winner();
						
		}
	}
	
	for (var i = up_index; i<= down_index; i++)
	{
		cell = document.getElementById("" + x + "_" + i);
		var classes = cell.className.split(" ");
		(classes.indexOf(searchClass) >= 0)?  (count++) : (count = 0) ;
		if (count == 5) 
		{
			winner();
						
		}
	}
	
	var tmp = 0;
	for (var i = left_index; i<= right_index; i++)
	{
		y1 = (up_index + tmp);
		if ( y1 > down_index) break;
		cell = document.getElementById("" + (i) + "_" + y1);
		var classes = cell.className.split(" ");
		(classes.indexOf(searchClass) >= 0)?  (count++) : (count = 0) ;
		if (count == 5) 
		{
			winner();
						
		}
		tmp ++;
	}
	
	tmp = 0;
	for (var i = right_index; i>= left_index; i--)
	{
		y1 = (up_index + tmp);
		if ( y1 > down_index) break;
		cell = document.getElementById("" + (i) + "_" + y1);
		var classes = cell.className.split(" ");
		(classes.indexOf(searchClass) >= 0)?  (count++) : (count = 0) ;
		if (count == 5) 
		{
			winner();
						
		}
		tmp ++;
	}
	
}

function winner ()
{
	var Player = "";
	if (TypeOfPlayer == "x") { Player = "Игрок Х"}
	else { Player = "Игрок O"};
	alert ("Победил " + Player);
	location.reload()
}


document.addEventListener("DOMContentLoaded", function() {
	
	document.getElementById("startGame").addEventListener("click", function() {
	var gameMenu = document.getElementById("gameMenu");
	var TimeForGame = document.getElementById("timeout").value*60;
	TimeOfPlayer_x = TimeForGame;
	TimeOfPlayer_o = TimeForGame;
	gameMenu.parentNode.removeChild(gameMenu);
		
	var field = document.getElementById("field");
	for(var row = 0; row < fieldHeight; row++) {
		var rowElement = document.createElement("div");
		rowElement.className = "row";
		field.appendChild(rowElement);
		
		for(var column = 0; column < fieldWidth; column++) {
			var cell = document.createElement("div");
			cell.id = "" + column + "_" + row;
			cell.className = "cell";
			rowElement.appendChild(cell);
			
			cell.addEventListener("click", function() {

				var classes = this.className.split(" ");				
				if ( (classes.indexOf("x") < 0) & (classes.indexOf("o") < 0) ) {
					classes.push(TypeOfPlayer);
					this.className = classes.join(" ");				
					CheckWin(this.id);
					InversePlayers();
				}
				
				
								
			});
		}
	}
	
	document.getElementById("game").className = "";
	
	player_x = document.getElementsByClassName("player x");
	player_x[0].className += " activ";
	var sp = player_x[0].getElementsByClassName("time");
	sp[0].innerHTML  = GetTextInterval(TimeForGame);
	
	player_o = document.getElementsByClassName("player o");
	var sp = player_o[0].getElementsByClassName("time");
	sp[0].innerHTML  = GetTextInterval(TimeForGame);
	
	setInterval(update, 1000);
	
})
});
