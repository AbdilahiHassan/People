"use strict";

    var PeopleBtn = document.getElementById("PeopleBtn");
var DetailInputElm = document.getElementById("textinput");
var ShowpersonDial = document.getElementById("DetailsBtn");
 var Closepersondetails = document.getElementById("Closepersondetails");
    //ResultdIV
    var resultDiv = document.getElementById("ResultDiv");
PeopleBtn.addEventListener("click", AjaxGetpeople);
ShowpersonDial.addEventListener("click", AjaxShowPersonDetails);
Closepersondetails.addEventListener("click", Closepersondeials);


    //Fetching all people data
function AjaxGetpeople(event) {
    console.log("OnSubmit Event: ", event);
        $.get("Ajax/PeoplePartialView", function (data, status) {
            console.log("Data: " + data + "\nStatus: " + status);
            resultDiv.innerHTML = data;
        });
    }
    // Posting data
function axajPostperson(event, id) {
    $.post("Ajax/DetailsPartialView",

        {
            id: DetailInputElm.value
        },
        function (data, status) {

            resultDiv.innerHTML = data;
        });
}
//personDeials

function AjaxShowPersonDetails(event) {
    event.preventDefault();
    console.log("OnDetials Event: ", event);
    console.log("DetailInputElm.value: ", DetailInputElm.value);
    $.post("/Ajax/DetailsPartialView",
        {
            id: DetailInputElm.value
        },
        function (data, status) {
            console.log("Data: " + data + "\nStatus: " + status);

            $("#person").html(data);
        }
    );
}

   //Close personDetails

    function Closepersondeials(event, id) {

        event.preventDefault();
        console.log("OnCloseDetials Event: ", event);

        console.log("id:", id);

        var anchorUrl = event.target.href;
        console.log("anchorUrl", anchorUrl);

        $.post(anchorUrl,
            {
                id: id
            },
            function (data, status) {
                console.log("Data: " + data + "\nStatus: " + status);
                //$("#person").html(data);
                $("#person" + id).html(data);
            }
        );
       
    }


