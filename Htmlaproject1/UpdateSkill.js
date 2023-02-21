function UpdateSkill(){
    document.getElementById("USkillsid").addEventListener("submit",function(event){
        event.preventDefault();
    });
    var skillId=document.getElementById("SkillId1").value;
    var skill=document.getElementById("Skill1").value;
    var trSkillId=document.getElementById("TrSkillId1").value;
   
   

    console.log(skillId);
    console.log(skill);
    console.log(trSkillId);

    

    
    fetch(`https://localhost:7265/TrSkillContoller/UpdateSkill`,
    {
        method:'PUT',
       
        body:
            JSON.stringify({
                "sid":skillId,
                'skill':skill,
                
                
                
                'trskillid':trSkillId
            }),
            headers:{
                'Content-Type':'application/json',
                
            },
    }).then(response=> {
        if(response.ok){
            alert("Experience added done Successfully");
        }
        else{
            alert("Experience failed");
        }
       
    })
    
}