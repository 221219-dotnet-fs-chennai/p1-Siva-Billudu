function UpdateEducation(){
    document.getElementById("UEducationid").addEventListener("submit",function(event){
        event.preventDefault();
    });
    var university=document.getElementById("University1").value;
    var degree=document.getElementById("Degree1").value;
    var CGpa=document.getElementById("CGPA1").value;
    var eid=document.getElementById("Eid1").value;
    var startDate=document.getElementById("StartDate1").value;
    var passOutDate=document.getElementById("PassOutDate1").value;
    var tREduid=document.getElementById("TrEduid1").value;

    console.log(university);
    console.log(degree);
    console.log(CGpa);
    console.log(eid);
    console.log(startDate);
    console.log(passOutDate);
    console.log(tREduid);

    
    fetch(`https://localhost:7265/TrEducation/UpdateEducation/${tREduid} `,
    {
        method:'PUT',
       
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
                'TrEduid':tREduid
                
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