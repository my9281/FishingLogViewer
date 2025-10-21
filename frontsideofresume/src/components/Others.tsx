export default function Others() {
    return (
        <>
            <div className="mb-6 dialog-box">
                <h2 className="text-xl font-bold text-white undertile-headertitle">AC-Fun Battle Royale Project</h2>
                <p className="italic text-gray-400 mb-0">2009 – Present</p>
                <p className="italic text-gray-400 mb-0">Role: System Administrator / Server GM / IT Operations Lead</p>
                <ul className="list-none pl-0 space-y-2">
                    {[
                        "Revived and maintained the web-based multiplayer game “Battle Royale”, originally built on Discuz! forum engine (PHP/MySQL), later extended into a standalone online platform.",
                        "Joined the open-source development team in 2013; took over server maintenance and IT infrastructure in 2015, managing DNS/ICP registration, backups, and security.",
                        "Led server migration and integration between “Dream” and “Time” servers after team restructuring; consolidated environments and restored player data with minimal downtime.",
                        "Oversaw infrastructure upgrades, including migration from shared hosting to dedicated VPS, deployment of Nginx/PHP-FPM stack, and performance tuning for thousands of concurrent players.",
                        "Managed project transition from open-source to closed-source governance post-2018, maintaining legacy repositories on GitHub while supporting live production environments."
                    ].map((text, i) => (
                        <li key={i} className="undertale-li" data-icon={i % 7}>{text}</li>
                    ))}
                </ul>
                <p> <a className="italic text-gray-400 mb-0" href="https://dlj.ymforever.com">ドルジ : dlj.ymforever.com</a></p>
                <p>  <a className="italic text-gray-400 mb-0" href="https://time.ymforever.com">Time-Zone : time.ymforever.com</a></p>
            </div>
            <div className="mb-6 dialog-box ">
                <h2 className="text-xl font-bold text-white undertile-headertitle">Minecraft Server Operations</h2>
                <p className="italic text-gray-400 mb-2">2016 – Present</p>
                <p className="italic text-gray-400 mb-0">Role: Server Administrator / DevOps</p>
                <ul className="list-none pl-0 space-y-2">
                    {[
                        "Built and maintained a self-hosted Minecraft server on Ubuntu Linux, managing full-stack deployment from initial setup to daily operations.",
                        "Installed and configured Forge and Fabric mod environments; coordinated community plugin integration and custom GUI management tools.",
                        "Implemented automated backup, access control, and network-level security measures after multiple intrusion attempts.",
                        "Managed updates, mod compatibility testing, and server performance optimization for stable multi-user gameplay.",
                        "Internal network deployment only (server address undisclosed for security reasons)."
                    ].map((text, i) => (
                        <li key={i} className="undertale-li" data-icon={i % 7}>{text}</li>
                    ))}
                </ul>
            </div>
            <div className="mb-6 dialog-box">
                <h2 className="text-xl font-bold text-white undertile-headertitle"> Icoding Network Authentication /Club </h2>
                <p className="italic text-gray-400 mb-0">2015 – Present</p>
                <p className="italic text-gray-400 mb-2">Role: Admin, System Operator, Windows Developer</p>
                <ul className="list-none pl-0 space-y-2">
                    {[
                        "Tech Stack: Java, Windows host injection, network authentication, web frontend, ChatGPT API (WebAI), Linux/Windows server ops",
                        "Developed and maintained a Java-based network authentication system, responsible for deployment, monitoring and incident troubleshooting.",
                        "Implemented Windows-host injection modules and local client utilities to support authentication and communication subsystems.",
                        "Managed club operations and platform infrastructure; created automation scripts to improve operational efficiency and recovery time.",
                        "During COVID, led/assisted in delivering an internal WebAI interface leveraging ChatGPT, enabling remote collaboration and testing.",
                        "Gained hands-on experience in authentication/security hardening, cross-platform ops, and lightweight AI integration."
                    ].map((text, i) => (
                        <li key={i} className="undertale-li" data-icon={i % 7}>{text}</li>
                    ))}
                </ul>
            </div>
        </>
    );
}