function AddSkill(){
    document.getElementById("Skillsid").addEventListener("submit",function(event){
        event.preventDefault();
    });
    var skillId=document.getElementById("SkillId").value;
    var skill=document.getElementById("Skill").value;
    var trSkillId=document.getElementById("TrSkillId").value;
   
   

    console.log(skillId);
    console.log(skill);
    console.log(trSkillId);

    

    
    fetch(`https://localhost:7265/TrSkillContoller/AddTrSkill
 `,
    {
        method:'POST',
       
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
        if(response.status==200){
            alert("Experience added done Successfully");
        }
        else{
            alert("Experience failed");
        }
       
    })
    
}