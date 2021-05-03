﻿"use strict";


    //Delaration and getting page info by ID
    var AllPeople = document.getElementById("allpeople");
    var PeopleBtn = document.getElementById("PeopleBtn");
    var DetailInputElm = document.getElementById("textinput");
var Closepersondetails = document.getElementById("Closepersondetails");
    //ResultdIV
    var resultDiv = document.getElementById("ResultDiv");
    //EventLitsnars
    AllPeople.addEventListener("click", AjaxGetpeople);
PeopleBtn.addEventListener("click", axajPostperson);

 //DetailInputElm.addEventListen("click", AjaxPersonDetails);
//onclic
    //DeleteBtn.addEventListener("click", axajGetperson);//Onclic
    

    //Fetching all data
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


    function AjaxPersonDetails(event,id) {
        event.preventDefault();
        console.log("OnDetials Event: ", event);

        console.log("id:", id);

        var anchorUrl = event.target.href;
        console.log("anchorUrl", anchorUrl);

        $.post(anchorUrl,
            {
                id: id
            },
            function (data, status) {
                console.log("Data: " + data + "\nStatus: " + status);

                $("#person" + id).replaceWith(data);
            }
        );
        
    }

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

                $("#person" + id).replaceWith(data);
            }
        );

    }

