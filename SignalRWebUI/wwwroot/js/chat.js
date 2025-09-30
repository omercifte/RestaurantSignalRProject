var connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5003/SignalRHub/")
    .build();

document.getElementById("sendbutton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    console.log(">>> ReceiveMessage tetiklendi:", user, message);

    var currentTime = new Date();
    var currentHour = currentTime.getHours().toString().padStart(2, '0');
    var currentMinute = currentTime.getMinutes().toString().padStart(2, '0');

    var li = document.createElement("li");
    li.className = "list-group-item"; // Bootstrap i�in

    var span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user + ": ";

    var text = document.createTextNode(`${message} - ${currentHour}:${currentMinute}`);

    li.appendChild(span);
    li.appendChild(text);

    document.getElementById("messagelist").appendChild(li);
});

connection.start().then(function () {
    console.log("SignalR ba�lant�s� ba�ar�l�");
    document.getElementById("sendbutton").disabled = false;
}).catch(function (err) {
    return console.error("SignalR ba�lant� hatas�:", err.toString());
});

document.getElementById("sendbutton").addEventListener("click", function (event) {
    var user = document.getElementById("userinput").value;
    var message = document.getElementById("messageinput").value;

    if (!user || !message) {
        return; // bo� mesaj g�ndermesin
    }

    console.log("G�nderiliyor:", user, message);

    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });

    // Mesaj g�nderildikten sonra input temizlensin
    document.getElementById("messageinput").value = "";

    event.preventDefault();
});

// Enter ile mesaj g�nderme (Shift+Enter = sat�r atla)
document.getElementById("messageinput").addEventListener("keypress", function (event) {
    if (event.key === "Enter" && !event.shiftKey) {
        event.preventDefault();
        document.getElementById("sendbutton").click();
    }
});
