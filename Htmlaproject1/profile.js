
function AddTrDetails(){
    document.getElementById("profileid").addEventListener("submit",function(event){
        event.preventDefault();
    });
    var email=document.getElementById("Email2").value;
    var password=document.getElementById("Password2").value;
    var fullname=document.getElementById("Fullname1").value;
    var trid=document.getElementById("TrId1").value;
    var phone=document.getElementById("Phone1").value;
    var website=document.getElementById("Website1").value;
    var gender=document.getElementById("Gender1").value;

    console.log(email);
    console.log(password);
    console.log(fullname);
    console.log(trid);
    console.log(phone);
    console.log(website);
    console.log(gender);

    
    fetch("https://localhost:7265/TrainerDetail/AddTrDetails",
    {
        method:'POST',
       
        body:
            JSON.stringify({
                email:email,
                password:password,
                fullname:fullname,
                trId:trid,
                phone:phone,
                website:website,
                gender:gender
            }),
            headers:{
                'Content-Type':'application/json',
                
            },
    }).then(response=> {
        if(response.ok){
            alert("Added done Successfully");
        }
        else{
            alert(" failed");
        }
       
    })
    
}