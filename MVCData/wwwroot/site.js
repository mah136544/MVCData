function GoToURL(url) {
    document.location = url;
}

function GetPeopleList(clearMessage = true) {
    $.get("/Ajax/GetPeopleList", null, function (data) {
        $("#OutputElement").html(data);
    });

    if (clearMessage)
        SetMessage("&nbsp;");
}

function GetPersonByID() {
    var personIDValue = document.getElementById('PersonIDInput').value;

    $.post("/Ajax/GetPersonById", { personID: personIDValue }, function (data) {
        $("#OutputElement").html(data);
    });

    SetMessage("&nbsp;");
}

function DeletePersonByID() {
    var personIDValue = document.getElementById('PersonIDInput').value;
    $.post("/Ajax/DeletePersonById", { personID: personIDValue }, function (data) { })
        .done(function () {
            SetMessage("Successfully deleted person.");

            var personIDInput = document.getElementById('PersonIDInput');
            if (personIDInput.max > 0) {
                personIDInput.max--;
            }

            GetPeopleList(false);
        })
        .fail(function () {
            SetMessage("Could not delete person.");
        });

}

function SetMessage(Message) {
    document.getElementById('Message').innerHTML = Message;
}

