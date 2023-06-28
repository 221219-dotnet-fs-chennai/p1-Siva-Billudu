function login(){
    document.getElementById("form1").addEventListener("submit",function(event){
        event.preventDefault();
    });

    var email=document.getElementById("Email").value;
    var password=document.getElementById("Password").value;

    console.log(email);
    console.log(password);

    
    fetch(`https://localhost:7265/Trainer/signIn?Email=${email}&Password=${password}`,{
        method:'GET',
        headers:{
            'Content-Type':'application/json',
           
        }
    }).then(response => {
        if(response.status==200){
            alert("Successfully Logged in");
             window.location.href='./view.html';
        }
        else{
            alert("Login Failed,please try again");
        }
    })
}

function SignUp(){
    document.getElementById("signid").addEventListener("submit",function(event){
        event.preventDefault();
    });
    var email=document.getElementById("Email1").value;
    var password=document.getElementById("Password1").value;
    var fullname=document.getElementById("Fullname").value;
    var trid=document.getElementById("TrId").value;
    var phone=document.getElementById("Phone").value;
    var website=document.getElementById("Website").value;
    var gender=document.getElementById("Gender").value;

    console.log(email);
    console.log(password);
    console.log(fullname);
    console.log(trid);
    console.log(phone);
    console.log(website);
    console.log(gender);

    
    fetch('https://localhost:7265/Trainer/signUp',
    {
        method:'POST',
       
        body:
            JSON.stringify({
                "email":email,
                'password':password,
                'fullname':fullname,
                'trId':trid,
                'phone':phone,
                'website':website,
                'gender':gender
            }),
            headers:{
                'Content-Type':'application/json',
                
            },
    }).then(response=> {
        if(response.status===200){
            alert("SignUp done Successfully");
        }
        else{
            alert("Signup failed");
        }
       
    })
    
}
