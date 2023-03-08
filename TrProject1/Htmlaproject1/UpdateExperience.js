function UpdateExperience(){
    document.getElementById("updateExperienceid").addEventListener("submit",function(event){
        event.preventDefault();
    });
    var Companyname=document.getElementById("CompanyName1").value;
    var companyid=document.getElementById("Companyid1").value;
    var companyType=document.getElementById("CompanyType1").value;
   
    var ExperienceinstartDate=document.getElementById("Experience in StartDate1").value;
    var ExperienceinlastDate=document.getElementById("Experience in LastDate1").value;
    var trcid=document.getElementById("TrCid1").value;

    console.log(Companyname);
    console.log(companyid);
    console.log(companyType);

    console.log(ExperienceinstartDate);
    console.log(ExperienceinlastDate);
    console.log(trcid);

    
    fetch(`https://localhost:7265/TrCompany/UpdateCompany/${trcid}`,
    {
        method:'PUT',
       
        body:
            JSON.stringify({
                "cid":companyid,
                'cname':Companyname,
                
                'ctype':companyType,
                'startyear':ExperienceinstartDate,
                'endyear':ExperienceinlastDate,
                'trcompanyid':trcid
            }),
            headers:{
                'Content-Type':'application/json',
                "Trcompanyid":trcid
                
            },
    }).then(response=> {
        if(response.status===200){
            alert("Experience added done Successfully");
        }
        else{
            alert("Experience failed");
        }
       
    })
    
}