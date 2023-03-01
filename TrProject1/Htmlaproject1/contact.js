function AddContact(){
    document.getElementById("Contactid").addEventListener("submit",function(event){
        event.preventDefault();
    });
    var Houseno=document.getElementById("HouseNo").value;
    var city=document.getElementById("City").value;
    var pincode=document.getElementById("Pincode").value;
    var addressid=document.getElementById("Addressid").value;
   

    console.log(Houseno);
    console.log(city);
    console.log(pincode);
    console.log(addressid);
   

    
    fetch("https://localhost:7265/TrContact/AddTrContact",
    {
        method:'POST',
       
        body:
            JSON.stringify({
                "lid":Houseno,
                'pincode':city,
                'city':pincode,
                'cid':addressid,
                
            }),
            headers:{
                'Content-Type':'application/json',
                
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