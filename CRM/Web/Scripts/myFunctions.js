
function GetYear(year, month, day)
{
    var now = new Date();            //сегодняшний день
    var mon = now.getMonth();      //месяц сейчас
    var den = now.getDate();        //день сейчас
    var god = now.getFullYear();        //год сейчас
    var chislo;

    var preden = day;                   //день рождения
    var premon = month;                  //месяц рождения
    var pregod = year;               //год рождения

    premon = (premon - 1);

    if (den >= preden & mon >= premon) { chislo = (god - pregod); }
    else if (den <= preden & mon > premon) { chislo = (god - pregod); }
    else if (den <= preden & mon <= premon) { chislo = (god - pregod - 1); }
    else if (den > preden & mon < premon) { chislo = (god - pregod - 1); }

    return (chislo);
}
    
function update ()
{
    var ListTimer =  document.getElementsByClassName("Timer");
    var TimeString = "";
    for(var i=0; i<ListTimer.length; i++) {
            
        WriteTime(ListTimer[i]);
    }

}

function WriteTime (Div)
{
    TimeString =  parseInt(Div.attributes.time.value);
    Div.innerHTML  = GetTextInterval(TimeString);
    Div.attributes.time.value = TimeString-1;
}

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


document.addEventListener("DOMContentLoaded", function() 
    {
        setInterval(update, 1000);
    }
)
