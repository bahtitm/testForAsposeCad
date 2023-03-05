let siginUp = document.getElementById("siginUp");

siginUp.addEventListener("submit", (e) => {
  e.preventDefault();
  let login = document.getElementById("login");
  let lastName = document.getElementById("lastName");
  let midelName = document.getElementById("midelName");
  let phone = document.getElementById("phone");  
  let password = document.getElementById("password");

  if (
    login.value == "" ||
    lastName.value == "" ||
    midelName.value == "" ||
    phone.value == "" ||    
    password.value == ""
  ) {
    alert("Ensure you input a value in both fields!");
  } else {
    console.log(
      `This form has a username of ${login.value} and password of ${password.value}`
    );
    console.log(login, lastName, midelName, phone, password)
    sigin(login.value, lastName.value, midelName.value, phone.value, password.value);

    login.value = "";
    password.value = "";
    login.value="";
    lastName.value="";
    midelName.value="";
    phone.value="";
    password.value="";
  }
});

function sigin(login, lastName, midelName, phone, password) {
    console.log(login, lastName, midelName, phone, password)
  var http = new XMLHttpRequest();
  var url = "https://localhost:7107/api/User";
  var params = JSON.stringify({
    
        "name": login,
        "lastNamre": lastName,
        "midelName": midelName,
        "phone": phone,
        "password": password,       
      
  });

  http.open("POST", url, true);

  http.setRequestHeader("accept", "application/json");
  http.setRequestHeader("Content-type", "application/json");

  http.onreadystatechange = function () {
    if (http.readyState == 4 && http.status == 200) {
      
      window.location.assign("/login.html");
      console.log("redirect");
    }
    if (http.readyState == 4 && http.status == 204) {
      
      window.location.assign("/login.html");
      console.log("redirect");
    }
  };
  http.send(params);

  console.log("send");
  return true;
}

