function UpdateContact(){
    document.getElementById("UContactid").addEventListener("submit",function(event){
        event.preventDefault();
    });
    var Houseno=document.getElementById("HouseNo1").value;
    var city=document.getElementById("City1").value;
    var pincode=document.getElementById("Pincode1").value;
    var cid=document.getElementById("Addressid1").value;
   

    console.log(Houseno);
    console.log(city);
    console.log(pincode);
    console.log(cid);
   

    
    fetch(`https://localhost:7265/TrContact/UpdateContact/${cid}`,
    {
        method:'PUT',
       
        body:
            JSON.stringify({
                "lid":Houseno,
                'pincode':city,
                'city':pincode,
                'cid':cid,
                
            }),
            headers:{
                'Content-Type':'application/json',
                'Cid':cid
                
            },
    }).then(response=> {
        if(response.status===200){
            alert("Address added done Successfully");
        }
        else{
            alert("Address failed");
        }
       
    })
    
}