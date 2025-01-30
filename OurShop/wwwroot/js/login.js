

const showRegister = () => {
    const registerDiv = document.querySelector(".registerHidden")

    registerDiv.classList.remove("registerHidden")

    registerDiv.classList.add("register")

}

const addUser = async  () => {
   const user =  newRegister()
    try {
        const responsePost = await fetch('https://localhost:7057/api/Users', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(user)

        })

        const dataPost = await responsePost.json()
        if (responsePost.ok)
            alert("Add user sucsessfully")
        /*alert(dataPost)*/
        else {
            if (responsePost.status === 400)
                alert("חוזק סיסמא לא תקין")
        }
    }
    catch (err) {
        alert(err)
    }
 

  
}

const getPassword = () => {
    const password = document.querySelector("#password").value
    return password;
}
const updateLevel = (dataPost) => {
    const level = document.querySelector("#level")
    console.log(level.value)
    level.value = dataPost
    console.log(level.value)
    
}


const cheakPassword = async () => {
    const password = getPassword()
    try {
        const responsePost = await fetch('https://localhost:7057/api/Users/password', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },

            body: JSON.stringify(password)

        })

        const dataPost = await responsePost.json()
        alert(dataPost)
        updateLevel(dataPost)
    }
    catch {
        alert(err)
    }
}


const newRegister = () => {
    const email = document.querySelector("#email").value

    const password = document.querySelector("#password").value

    const firstName = document.querySelector("#firstName").value

    const lastName = document.querySelector("#lastName").value

    const user = {email, password, firstName, lastName }

    return user
}


const userLogin = () => {
    const email = document.querySelector("#emailLogin").value
    const password = document.querySelector("#passwordLogin").value

    const user = { email, password}
    return user
}

const fetchLogin = async () => {
    const user = userLogin()

    try {
        const responsePost = await fetch(`https://localhost:7057/api/Users/login/?email=${user.email}&password=${user.password}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            query: {
                email: user.email,
                password: user.password
            }
           

        })
       
        const postData = await responsePost.json()
        if (responsePost.ok) {
            console.log('post data:', postData)

            sessionStorage.setItem("Name", postData.firstName)
            sessionStorage.setItem("Id", postData.id)
            window.location.href = "userDetails.html"
        }
        else {
            alert("שדות חובה")
        }
    }
    catch (err) {
        alert(err)
    }

}