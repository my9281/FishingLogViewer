export default function Projects() {
  return (
   <>
   <div className="mb-6 dialog-box">
  <h2 className="text-xl font-bold text-white undertile-headertitle">MullenLowe Profero – Backend Software Engineer</h2>
  <p className="italic text-gray-400 mb-0">Aug 2020 – Jan 2023 · Beijing, China</p>
  <ul className="list-none pl-0 space-y-2">
    {[
  "Delivered enterprise web platforms for ChinaChem Group, Nina Hotel Group (Millennium & Langham Hotels), and maintained Diageo corporate websites.",
"Supported IT operations: set up internal test environments for Apple’s iPhone web translation team during COVID, and assisted with Active Directory / Microsoft account integration and internal software deployments.",
"Built solutions on Sitecore CMS (.NET Framework) and Umbraco CMS, integrating SQL Server, MongoDB, and Redis for data management.",
"Deployed on AWS and Azure cloud platforms, implementing automated CI/CD pipelines (AWS/Azure Pipelines, Bitbucket/GitLab) for release management.",
"Implemented advanced search functionality using Azure Cognitive Search and Solr, enabling multilingual and category-based hotel search.",
"Integrated Salesforce CRM via OAuth for customer data workflows, applying .NET pipeline injection techniques to customize business logic.",
"CCG & Nina Hotel Group: Ensured on-time launch for client’s anniversary campaign; optimized CI/CD release pipelines and Solr scripts, reducing deployment time from 4 hours to 7 minutes; led successful customer data migration.","Diageo: Maintained multilingual version of the “What’s Your Whisky” sub-project on Umbraco CMS, supporting global marketing campaigns.",
"Millennium Hotel: Delivered mobile app & mini-program APIs, enabling seamless booking and service access across platforms.",
"Apple (COVID support): Set up internal test servers and provided compliant localization management, minimizing team exposure risks during pandemic restrictions."

    ].map((text, i) => (
      <li key={i} className="undertale-li" data-icon={i % 7}>{text}</li>
    ))}
  </ul>
</div>
<div className="mb-6 dialog-box ">
  <h2 className="text-xl font-bold text-white undertile-headertitle">CQ horizone Ltd Co. – Independent Technical Exploration</h2>
  <p className="italic text-gray-400 mb-2">Mar 2017 – Dec 2019 · Beijing, China</p>
  <ul className="list-none pl-0 space-y-2">
    {[
      "Participated in a cross-functional R&D group focused on real-time geographic simulation systems for government logistics planning",
      "Developed core visualization modules using Unity3D, integrating ArcGIS datasets for high-fidelity terrain rendering and layered spatial analysis",
      "Engineered dual-interface rendering architecture: WebGL for browser-based exploration and WPF desktop client for internal simulation control",
      "Built modular support for a custom Simulation Engine, enabling scenario playback, time-sequenced event triggers, and spatial data overlays",
      "Explored atmospheric effects including dynamic cloud layers, volumetric rendering, and custom sky-axis tracking models",
      "System demonstrated at a national-level logistics event; showcased via CCTV News and officially recognized by government partners",
      "Developed under partial confidentiality due to state-involved simulation context"
    ].map((text, i) => (
      <li key={i} className="undertale-li" data-icon={i % 7}>{text}</li>
    ))}
  </ul>
</div>
<div className="mb-6 dialog-box">
  <h2 className="text-xl font-bold text-white undertile-headertitle">ALT Group – System Technical Lead</h2>
  <p className="italic text-gray-400 mb-2">Aug 2015 – Feb 2017 · Ordos, Inner Mongolia, China</p>
  <ul className="list-none pl-0 space-y-2">
    {[
      "Led redevelopment of a legacy Transportation Management System (TMS) into a distributed SaaS-based platform, deployed across multiple logistics stations",
      "Designed a modular Warehouse Management System (WMS) aligned with commercial high-availability models, supporting real-time inventory visibility and station-level dispatch",
      "Built a middleware integration layer to synchronize TMS and an external OMS, incorporating WCF-based APIs, PLC hardware channels, and barcode/RFID modules for on-site tracking",
      "Delivered a lightweight custom mobile client for scanning terminals used in station-side workflows (multi-code recognition, Win-based devices)",
      "Managed stakeholder communication and user training during system rollout across a 600-hectare logistics park",
      "Provided full-stack technical leadership, covering database synchronization, API orchestration, and edge middleware deployment",
      "System remains operational as a key logistics hub in Inner Mongolia, compliant with regulatory and audit requirements"
    ].map((text, i) => (
      <li key={i} className="undertale-li" data-icon={i % 7}>{text}</li>
    ))}
  </ul>
</div>

   </>
  );
}