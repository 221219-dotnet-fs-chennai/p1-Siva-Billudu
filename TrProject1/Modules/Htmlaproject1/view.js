//for Get Trainer
fetch(`https://localhost:7265/TrainerDetail/GetTrDetails
`)
.then(Response=>Response.json())
.then(data=>data.forEach(trainer =>{
    const markup=`<ol>
    <h2>Trainer Details</h2>
    Name:${trainer.fullname}<br>
    Email:${trainer.email}<br>
    Password:${trainer.password}<br>
    TrId:${trainer.trid}<br>
    Phone:${trainer.phone}<br>
    Website:${trainer.website}<br>
    Gender:${trainer.gender}<br>

    </ol>`

        document.querySelector("ol").insertAdjacentHTML('beforeend',markup);
}))


// for get education details
fetch(`https://localhost:7265/TrEducation/GetTrEducations
`)
.then(Response=>Response.json())
.then(data=>data.forEach(trainer=>{
    const markup=`<ol>
    <h2>Education Details</h2>
    Eid:${trainer.eid}<br>
    TUniversity:${trainer.tuniversity}<br>
    HDegreeName:${trainer.hdegreeName}<br>
    CGpa:${trainer.cgpa}<br>
    StartDate:${trainer.startdate}<br>
    PassoutDate:${trainer.passoutDate}<br>
    Treduid:${trainer.trEduid}<br>
    </ol>`
    document.querySelector("ol").insertAdjacentHTML('beforeend',markup);
}))
//for company details
fetch(`https://localhost:7265/TrCompany/GetTrCompany
`)
.then(Response=>Response.json())
.then(data=>data.forEach(trainer=>{
    const markup=`<ol>
    <h2>Experience Details</h2>
    CId:${trainer.cid}<br>
    cName:${trainer.cname}<br>
    cType:${trainer.ctype}<br>
    startYear:${trainer.startyear}<br>
    Endyear:${trainer.endyear}<br>
    Trcompanyid:${trainer.trcompanyid}<br>
    </ol>`
    document.querySelector("ol").insertAdjacentHTML('beforeend',markup);
}))
//for contact details
fetch(`https://localhost:7265/TrContact/GetTrContact
`)
.then(Response=>Response.json())
.then(data=>data.forEach(trainer=>{
    const markup=`<ol>
    <h2>Contact Details</h2>
    LId:${trainer.lid}<br>
    Pincode:${trainer.pincode}<br>
    City:${trainer.city}<br>
    contactid:${trainer.cid}<br>
    </ol>`
    document.querySelector("ol").insertAdjacentHTML('beforeend',markup);
}))
//for Skill Details
fetch(`https://localhost:7265/TrSkillContoller/GetTrSkill
`)
.then(Response=>Response.json())
.then(data=>data.forEach(trainer=>{
    const markup=`<ol>
    <h2>Skill Details</h2>
    SkillId:${trainer.sid}<br>
    Skillname:${trainer.skill}<br>
    Trskillid:${trainer.trskillid}<br>
    </ol>`
    document.querySelector("ol").insertAdjacentHTML('beforeend',markup);
}))