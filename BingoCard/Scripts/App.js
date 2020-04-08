var card;

window.onload = function () {
    alert("Hello!");
    card = @Html.Raw(Json.Encode(@Model));
}

function markSquare(number) {
    //Change the color
    document.getElementById(number).classList.toggle('btnMarked');

    //Find the Line and square in the array
    var isFoundSquare = false;
    var isExiting = false;
    var isNotInLine = false;
    var posLine = 0;
    var posSquare = 0;

    var i = 0;
    while (!isExiting) {
        var j = 0;
        isNotInLine = false;
        while (!isFoundSquare && !isNotInLine) {
            if (card.Lines[j].Number === number) {
                //Number matched
                posSquare = j;
                isFoundSquare = true;
                isExiting = true;
            }
            else {
                //Number not matched
                j++;
                //Fix the "line"
                if (j < 9) { posLine = 0; }
                else if (j >= 9 && j < 18) { posLine = 1; }
                else if (j >= 18 && j < 27) { posLine = 2; }
                else if (j > 27) { isNotInLine = true; }
            }
        }
        //Go to next "line"
        i++;
        if (i > 2) { isExiting = true; }
    }
    //No matched number (never success XD)
    if (!isFoundSquare) { alert("ERROR: No match for number " + number + ": i:" + i + ",j:" + j); }
    else {
        //Square matched
        //Mark the square
        //No previous marked
        if (!card.Lines[posSquare].isMarked) {
            //No previous marked
            card.Lines[posSquare].isMarked = true;
            //Add +1 count to line counter
            var count = card.MarkedSquares[posLine];
            card.MarkedSquares[posLine] = 1 + count;
        }
        else {
            //Previous marked
            card.Lines[posSquare].isMarked = false;
            //Check if this line had line
            var count = card.MarkedSquares[posLine];
            if (card.Isline = true && count > 4) { card.IsLine = false; }
            //Sub -1 count to line counter
            card.MarkedSquares[posLine] = count - 1;
        }

        //TODO: POST Controller call
        //Verify if is line ( Marked > 4)
        if (card.MarkedSquares[posLine] > 4 && !card.IsLine) {
            //Block next lines msg
            card.IsLine = true;
            //Show the alert msg
            $("#line-popup").modal();
        }
    }
}