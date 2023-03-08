function DeleteTrDetails(){
    document.getElementById("Dprofileid").addEventListener("submit",function(event){
        event.preventDefault();
    });
   
    var fullname=document.getElementById("Fullname2").value;
   

    
    console.log(fullname);

    
    fetch(`https://localhost:7265/TrainerDetail/DeleteTrDetails?Fullname=${fullname}`,
    {
        method:'DELETE',
       
        
            headers:{
                'Content-Type':'application/json',
                
            },
    }).then(response=> {
        if(response.status===200){
            alert("delete done Successfully");
        }
        else{
            alert(" failed");
        }
       
    })
    
}