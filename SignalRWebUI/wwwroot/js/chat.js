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
    li.className = "list-group-item"; // Bootstrap için

    var span = document.createElement("span");
    span.style.fontWeight = "bold";
    span.textContent = user + ": ";

    var text = document.createTextNode(`${message} - ${currentHour}:${currentMinute}`);

    li.appendChild(span);
    li.appendChild(text);

    document.getElementById("messagelist").appendChild(li);
});

connection.start().then(function () {
    console.log("SignalR baðlantýsý baþarýlý");
    document.getElementById("sendbutton").disabled = false;
}).catch(function (err) {
    return console.error("SignalR baðlantý hatasý:", err.toString());
});

document.getElementById("sendbutton").addEventListener("click", function (event) {
    var user = document.getElementById("userinput").value;
    var message = document.getElementById("messageinput").value;

    if (!user || !message) {
        return; // boþ mesaj göndermesin
    }

    console.log("Gönderiliyor:", user, message);

    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });

    // Mesaj gönderildikten sonra input temizlensin
    document.getElementById("messageinput").value = "";

    event.preventDefault();
});

// Enter ile mesaj gönderme (Shift+Enter = satýr atla)
document.getElementById("messageinput").addEventListener("keypress", function (event) {
    if (event.key === "Enter" && !event.shiftKey) {
        event.preventDefault();
        document.getElementById("sendbutton").click();
    }
});
