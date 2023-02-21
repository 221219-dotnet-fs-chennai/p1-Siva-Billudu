function AddExperience(){
    document.getElementById("Experienceid").addEventListener("submit",function(event){
        event.preventDefault();
    });
    var Companyname=document.getElementById("CompanyName").value;
    var companyid=document.getElementById("Companyid").value;
    var companyType=document.getElementById("CompanyType").value;
   
    var ExperienceinstartDate=document.getElementById("Experience in StartDate").value;
    var ExperienceinlastDate=document.getElementById("Experience in LastDate").value;
    var Trcid=document.getElementById("TrCid").value;

    console.log(Companyname);
    console.log(companyid);
    console.log(companyType);

    console.log(ExperienceinstartDate);
    console.log(ExperienceinlastDate);
    console.log(Trcid);

    
    fetch(`https://localhost:7265/TrCompany/AddTrCompany
   `,
    {
        method:'POST',
       
        body:
            JSON.stringify({
                "cid":companyid,
                'cname':Companyname,
                
                'ctype':companyType,
                'startyear':ExperienceinstartDate,
                'endyear':ExperienceinlastDate,
                'trcompanyid':Trcid
            }),
            headers:{
                'Content-Type':'application/json',
                
            },
    }).then(response=> {
        if(response.status==200){
            alert("Experience added done Successfully");
        }
        else{
            alert("Experience failed");
        }
       
    })
    
}