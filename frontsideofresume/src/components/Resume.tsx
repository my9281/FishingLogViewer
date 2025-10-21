export default function Resume() {


    const heartItems = [
        "Backend engineer with 8+ years of experience in .NET development, specializing in C#, ASP.NET Core, API design, and scalable system architecture.",
        "Led or contributed to engineering initiatives across MullenLowe, Microsoft-linked platforms, and Apple-adjacent projects, delivering backend solutions integrated with Azure and CI/CD pipelines. Certified in PMP and MCSA (Web Applications), combining system engineering depth with disciplined project execution.",
        "Legally authorized to work in the U.S. (EAD – C09, marriage-based green card process); no employer sponsorship required."
    ];

    const skillItems = [
        "Backend: C#, ASP.NET core (.NET 9), RESTful API, OAuth2.0, WPF, WCF, middleware architecture",
        "Cloud Platforms: Microsoft Azure, basic AWS exposure",
        "Databases: MySQL, SQL Server, Oracle, MongoDB, Elasticsearch, Redis",
        "DevOps: Jenkins, Docker, Kubernetes, multi-environment CI/CD",
        "Frontend: React, Vite/Webpack build; Vue, JQuery",
        "Tools: Git, Docker, Visual Studio"
    ];

    const certItems = [
        "PMP – Project Management Professional (PMI), 2020",
        "MCSA: Web Applications – Microsoft Certified Solutions Associate, 2019"
    ];

    const langItems = [
        "Mandarin Chinese – Native",
        "English – Professional working proficiency"
    ];

    const eduItems = [
        "Beijing Information Science and Technology University, Beijing, China\nBachelor of Engineering (B.E.) in Automation\nSep 2010 – Jul 2014",
        "Tianjin University, Tianjin, China\nMaster-level Coursework in Human Resource Management\nSep 2015 – Jan 2018"
    ];

    const renderHeartList = (items: string[], title : string) => (
        <div className="dialog-box"> 
            <h2 className="text-2xl font-bold undertile-headertitle">{title}</h2>
            <ul className="list-none space-y-2">
                {items.map((text: string, idx: number) => (
                    <li key={idx} className="undertale-li" data-icon={idx % 7}>{text}</li>
                ))}
            </ul>
        </div>
    );

    return (
        <section> 
            {renderHeartList(heartItems,"Summary")} 
            {renderHeartList(skillItems,"Skills")} 
            {renderHeartList(certItems,"Certifications")}  
            {renderHeartList(eduItems,"Education")}
            {renderHeartList(langItems,"Languages")}
        </section>
    );
}