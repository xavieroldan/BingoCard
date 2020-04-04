function toogleColor() {
    $.ajax({
        type: "POST",
        url: "/CardController/NumberToogle",
        headers: { "cache-control": "no-cache" },
        contentType: 'application/json',
        data: JSON.stringify({ param: myParameter }),
        success: function (result) {
            alert("success");

        },
        failure: function (error) {
        }
    });
}



