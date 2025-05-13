const Register = async () => {

    const firstName = document.getElementById("first_name").value
    const lastName = document.getElementById("last_name").value
    const password = document.getElementById("psw").value
    const userName = document.getElementById("user_name").value
    console.log(firstName, lastName, userName, password)

    if (!firstName)
        console.log(firstName + " is required")
    if (!lastName)
        console.log(lastName + " is required")
    if (!password)
        console.log(password + " is required")
    if (!userName)
        console.log(userName + " is required")

    const user = {
        firstName: firstName,
        lastName: lastName,
        userName: userName,
        password: password
    }

    const responsePost = await fetch('api/User/register', {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(user)

    });
    if (!responsePost.ok) {
        if (responsePost.status == 409) {
            alert("already exist")
        }
        else {
            alert("insert a stronger password")
        }
    }
}

const login = async () => {
    const password = document.getElementById("Lpsw").value
    const userName = document.getElementById("Luser_name").value
    const user = {
        password: password,
        userName: userName
    }
    if (!password)
        console.log(password + " is required")
    if (!userName)
        console.log(userName + " is required")

    const response = await fetch('api/User/login', {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(user)
    });
    const userDetails= await response.json()
    console.log(userDetails)
    if (response.ok) {
        alert(userName + " login succes")
    }
    else {
        alert("Unauthorized")
    }

    localStorage.setItem("userId", userDetails.id)

}



const upDate = async () => {
    const firstName = document.getElementById("Ufirst_name").value
    const lastName = document.getElementById("Ulast_name").value
    const password = document.getElementById("Upsw").value
    const userName = document.getElementById("Uuser_name").value
    const id = localStorage.getItem("userId")
    const user = {
        id:id,
        firstName: firstName,
        lastName: lastName,
        userName: userName,
        password: password
    }


    const responsePost = await fetch(`api/User/${id}`, {
        method: 'Put',
        headers: {
            'Content-Type': 'application/json',
        },
        body:JSON.stringify(user)

    });

    if (responsePost.ok) {
        alert("updated")
    }
}


const checkPasswordStrong = async() => {
    const password = document.getElementById("psw").value;
    const response = await fetch('api/User/checkPassword', {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(password)
    })
    const strong = await response.json();
    alert(strong);
}