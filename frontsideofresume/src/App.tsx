type LanDict = Record<string, Record<string, string>>;
import lan from './common/commonlan.json';
const typedLan = lan as LanDict;
import { useState } from 'react'
import Header from "./components/Header.tsx";
import Resume from "./components/Resume.tsx";
import Projects from "./components/Projects.tsx";
import Others from "./components/Others.tsx";
import Notes from "./components/Notes.tsx";
import FloatingMusicPlayer from "./components/bgm.tsx";
import './App.css'
let lang = "";
function Dic(key: string): string {
    return typedLan[lang][key] ?? "Error！";
}
function App() {
    lang = navigator.language.startsWith("zh") ? "cn" : "en";
    console.log(Dic("welcomeword"));
    const [tab, setTab] = useState("resume");
    return (
        <>
            <div className="min-h-screen bg-gray-50 text-gray-800 font-sans">
                <Header />
                <nav className="flex justify-center space-x-6 mt-6 text-lg">
                    <button onClick={() => setTab("resume")} className="undertile-enable-button"  >
                        <span className="undertale-selector">
                            {tab === "resume" ? "\u2665" : " "}
                        </span>
                        Infomation
                    </button>
                    <button onClick={() => setTab("projects")} className="undertile-enable-button" >
                        <span className="undertale-selector">
                            {tab === "projects" ? "\u2665" : " "}
                        </span>
                        Projects
                    </button>
                    <button onClick={() => setTab("Others")} className="undertile-enable-button">
                        <span className="undertale-selector">
                            {tab === "Others" ? "\u2665" : " "}
                        </span>
                        Others
                    </button>

                    <button onClick={() => setTab("Notes")} className="undertile-enable-button">
                        <span className="undertale-selector">
                            {tab === "Notes" ? "\u2665" : " "}
                        </span>
                        Notes
                    </button>
                </nav>
                <main className="max-w-4xl mx-auto mt-8 p-4">
                    {tab === "resume" && <Resume />}
                    {tab === "projects" && <Projects />}
                    {tab === "Others" && <Others />}
                    {tab === "Notes" && <Notes />}
                </main>
            </div>
            <div className="float-music">
                <FloatingMusicPlayer />
            </div>
        </>
    );
}
export default App
