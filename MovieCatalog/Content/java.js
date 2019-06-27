function setvisible(vis) {
    var logincontainer = document.getElementById('logincontainer');
    if (vis == '0')
        logincontainer.style.visibility = 'hidden';
    else
        logincontainer.style.visibility = 'visible';

    var halfreg = document.getElementById('halfreg');
    halfreg.style.width = '49%';
    var halfjoin = document.getElementById('halfjoin');
    halfjoin.style.display = 'inline-block';
    halfreg.type = 'button';
    var logform = document.getElementById('logform');
    logform.action = "/Home/Login";
}

function setregister() {
    var halfreg = document.getElementById('halfreg');

    if (halfreg.style.width != '100%') {
        halfreg.style.width = '100%';

        var halfjoin = document.getElementById('halfjoin');
        halfjoin.style.display = 'none';
    }
    else {
        var login = document.getElementById('login');
        var password = document.getElementById('password');

        if (login.value != '' && password.value != '') {
            var logform = document.getElementById('logform');
            logform.action = "/Home/Register";

            halfreg.type = 'submit';
        }
        else {
            alert('Заполните поля');
        }
    }
    
}

function setimage() {
    var file = document.getElementById('file');
    if (file.files && file.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $('#posterimage').attr('src', e.target.result);
            $('#postersrc').attr('value', e.target.result);
        }
        reader.readAsDataURL(file.files[0]);
    }
}



