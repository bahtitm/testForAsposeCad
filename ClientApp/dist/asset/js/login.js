let loginForm = document.getElementById("loginForm");

loginForm.addEventListener("submit", (e) => {
  e.preventDefault();

  let username = document.getElementById("username");
  let password = document.getElementById("password");

  if (username.value == "" || password.value == "") {
    alert("Ensure you input a value in both fields!");
  } else {
    console.log(
      `This form has a username of ${username.value} and password of ${password.value}`
    );
    login(username.value, password.value);
    

    username.value = "";
    password.value = "";
  }
});

function login(username, password) {
  var http = new XMLHttpRequest();
  var url = "https://localhost:7107/api/Authentication";
  var params = JSON.stringify({
    name: username,
    password: password,
  });

  http.open("POST", url, true);

  http.setRequestHeader("accept", "application/json");
  http.setRequestHeader("Content-type", "application/json");

  http.onreadystatechange = function () {
    if (http.readyState == 4 && http.status == 200) {      
      localStorage.setItem("token", http.responseText);
      window.location.assign("/index.html");     
    }
  };
  http.send(params);

  console.log("send");
  return true;
}
function siginUp()
{
    window.location.assign("/siginUp.html");
}
