window.onload = function () {
  document
    .querySelector("#GetStatusButton")
    .addEventListener("click", getStatus);
};

function getStatus() {
  var id = document.querySelector("#idInput").value;
  console.log(id);
  var url = "../StoreTableAPI/txn/" + id;
  var xmlhttp = new XMLHttpRequest();
  xmlhttp.onreadystatechange = function () {
    if (xmlhttp.readyState === 4 && xmlhttp.status === 200) {
      var resp = xmlhttp.responseText;
      if (resp.search("ERROR") >= 0) {
        alert("oh no...");
        console.log(resp);
      } else {
        console.log(resp);
        ShowStatusPanel(resp);
      }
    }
  };
  xmlhttp.open("GET", url, true);
  xmlhttp.send();
}

function ShowStatusPanel(text) {
  let status = text;
  let span = document.querySelector("#OrderSpan").innerHTML;
  document.querySelector("#OrderDIV").classList.remove("hidden");
  if (status != "") {
    document.querySelector("#OrderSpan").innerHTML = status;
  } else {
    document.querySelector("#OrderSpan").innerHTML = "Not Found";
  }
}
