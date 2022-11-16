function emailSubmit() {
  if (document.querySelector(".email-input").value.length < 4) {
    alert("Email должен быть больше 4 символов");
    return false;
  }

  if (document.querySelector(".message-input").value.length < 10) {
    alert("Сообщение должено быть больше 10 символов");
    return false;
  }

  if (!document.querySelector(".not-robot-check").checked) {
    alert("Нужна галочкак 'я не робот'");
    return false;
  }

  window.open("mailto:" + document.querySelector(".email-input").innerHTML);
  return true;
}

function getBrowserName(agent) {
  switch (true) {
    case agent.indexOf("edge") > -1:
      return "MS Edge";
    case agent.indexOf("edg/") > -1:
      return "Edge ( chromium based)";
    case agent.indexOf("opr") > -1 && !!window.opr:
      return "Opera";
    case agent.indexOf("chrome") > -1 && !!window.chrome:
      return "Chrome";
    case agent.indexOf("trident") > -1:
      return "MS IE";
    case agent.indexOf("firefox") > -1:
      return "Mozilla Firefox";
    case agent.indexOf("safari") > -1:
      return "Safari";
    default:
      return "other";
  }
}

let brName = getBrowserName(window.navigator.userAgent.toLowerCase());

if (brName !== "Opera"){
    //alert("Ваш браузер " + brName + ". Необходимо использовать браузер Opera для корректного отображения")
}