function AddEducation(){
    document.getElementById("Educationid").addEventListener("submit",function(event){
        event.preventDefault();
    });
    var university=document.getElementById("University").value;
    var degree=document.getElementById("Degree").value;
    var CGpa=document.getElementById("CGPA").value;
    var eid=document.getElementById("Eid").value;
    var startDate=document.getElementById("StartDate").value;
    var passOutDate=document.getElementById("PassOutDate").value;
    var tREduid=document.getElementById("TrEduid").value;

    console.log(university);
    console.log(degree);
    console.log(CGpa);
    console.log(eid);
    console.log(startDate);
    console.log(passOutDate);
    console.log(tREduid);

    
    fetch(`https://localhost:7265/TrEducation/AddTrEducation
    `,
    {
        method:'POST',
       
        body:
            JSON.stringify({
                "eid":eid,
                'tuniversity':university,
                'hdegreeName':degree,
                'cgpa':CGpa,
                'startdate':startDate,
                'passoutDate':passOutDate,
                'trEduid':tREduid
            }),
            headers:{
                'Content-Type':'application/json',
                
            },
    }).then(response=> {
        if(response.status===200){
            alert("Education added done Successfully");
        }
        else{
            alert("Education failed");
        }
       
    })
    
}