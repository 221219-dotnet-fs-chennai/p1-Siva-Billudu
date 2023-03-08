function UpdateTrDetails(){
    document.getElementById("updateprofileid").addEventListener("submit",function(event){
        event.preventDefault();
    });
    var email=document.getElementById("Email3").value;
    var pssword=document.getElementById("Password3").value;
    var fullname=document.getElementById("Fullname2").value;
    var trid=document.getElementById("TrId2").value;
    var phone=document.getElementById("Phone2").value;
    var website=document.getElementById("Website2").value;
    var gender=document.getElementById("Gender2").value;

    console.log(email);
    console.log(pssword);
    console.log(fullname);
    console.log(trid);
    console.log(phone);
    console.log(website);
    console.log(gender);

    
    fetch(`https://localhost:7265/TrainerDetail/UpdateTrainer/${trid}`,
    {
     
        method:'PUT',
       
        body:
            JSON.stringify({
                email:email,
                password:pssword,
                fullname:fullname,
                trId:trid,
                phone:phone,
                website:website,
                gender:gender
            }),
            headers:{
                'Content-Type':'application/json',
                "TrId":trid
                
            },
    }).then(response=> {
        if(response.ok){
            console.log("ho");
            alert("Updated done Successfully");
        }
        else{
            alert(" failed");
        }
       
    })
    
}