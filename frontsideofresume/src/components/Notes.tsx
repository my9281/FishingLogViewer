
import { useState } from 'react';

export default function Notes() {
    const [title, setTitle] = useState('');
    const [user, setUser] = useState('');
    const [text, setText] = useState('');

    const qaList = [
        [" Why did you make this page?",
            "I used Vite to build this page. As a backend developer, I don’t want to just show what I’ve done — I’d rather demonstrate what I’m capable of. This page is a way to show my front-end proficiency through something tangible."],
        ["The page looks quite simple. It doesn’t seem to show much.",
            "It may look simple, but it’s fully built with React, including both front-end rendering and back-end communication. For example, the animation at the top is drawn with a canvas pixel matrix, and the Message Board section interacts with the server in real time. These cover most aspects of a traditional web application.The backend is built on.NET 9, and the project uses a multi - route architecture, which I implemented myself."]
        ,
        ["What do you think are the weaknesses of this site?",
            "There are certainly some areas for improvement — for instance, I haven’t yet optimized the responsive layout for mobile devices, and some mobile browsers still have compatibility issues. I plan to refine these gradually."],
        ["Your interface uses a rather unusual style.Why?",
            "The design is inspired by Undertale. The seven hearts represent the seven human virtues — red for Determination, orange for Bravery, yellow for Justice, green for Kindness, light blue for Patience, dark blue for Integrity, and purple for Perseverance.Of course, these colors can also be inverted to represent the seven deadly sins — Pride, Envy, Wrath, Sloth, Greed, Gluttony, and Lust.Recently, while applying for jobs, I came across many church - related projects, which inspired me to learn more about religious stories and symbolism in my free time.So I do that."]
        ,
    ];


    const handleSubmit = () => {
        const formData = { ntitle: title, nuser: user, ntext: text };
        console.log(formData);
        fetch('/api/cms/AddNote', {
            method: 'POST',
            body: new URLSearchParams(formData)
        })
            .then(res => res.text())
            .then(response => {
                alert(response);
            })
            .catch(() => alert('service error.'));

    };

    return (
        <>
            <div className="mb-6 dialog-box">
                <h2 className="text-xl font-bold text-white undertile-headertitle">Notes</h2>
                <ul className="list-none pl-0 space-y-2">
                    {[
                        "If you're interested in my personal life or hobbies, I’d be more than happy to share.Outside of work, I really enjoy playing games. As a video creator, I’ve recorded and edited lots of gameplay videos and board game clips.Besides that, I also love writing novels. If you’re curious, you can search for “Dawn of Destiny – The Ashes of Fate” on the Tomato Novel platform to read my work.Thank you for taking the time to read all the way to here.",
                        "In addition, I’m also deeply interested in artificial intelligence — from the early days of big data analysis and blockchain to the current era of large language models. believe embracing cutting-edge technology is a worthwhile pursuit.Although it may lead to the disappearance of certain jobs, just like the two Industrial Revolutions before, society continues to move forward.We shouldn’t hinder the progress of technology for the sake of short-term interests, should we?",
                        "— Thomas Chen"

                    ].map((text, i) => (
                        <li key={i} className="undertale-li" data-icon={i % 7}>{text}</li>
                    ))}
                </ul>
            </div>
            <div className="mb-6 dialog-box">
                <h2 className="text-xl font-bold text-white undertile-headertitle">Message board</h2>
                <table>
                    <tr>
                        <td className="Note-Table-Subtitle">
                            <span>Message Title：</span>
                        </td>
                        <td className="Note-Table-Content">
                            <input id="title" value={title}
                                onChange={e => setTitle(e.target.value)}></input>
                        </td>
                    </tr>
                    <tr>
                        <td className="Note-Table-Subtitle">
                            <span>Your Name：</span>
                        </td>
                        <td className="Note-Table-Content">
                            <input id="user" value={user}
                                onChange={e => setUser(e.target.value)}></input>
                        </td>
                    </tr>
                </table>
                <div className="Content-Title-Border">
                    <span className="Content-Title">Content:</span>
                </div>
                <textarea className="txtar"
                    id="text"
                    value={text}
                    onChange={e => setText(e.target.value)}></textarea>
                <button className="login_btn" id="submit" onClick={handleSubmit}>Send it</button>
            </div>

            <div className="mb-6 dialog-box">
                <h2 className="text-xl font-bold text-white undertile-headertitle">Q & A</h2>
                <ul className="list-none pl-0 space-y-2">
                    {qaList.map(([q, a], i) => (
                        <li key={i} className="undertale-li" data-icon={i % 7}>
                            <p><strong>Q:</strong> {q}</p>
                            <p><strong>A:</strong> {a}</p>
                        </li>
                    ))}
                </ul>

            </div>

            <div className="mb-6 dialog-box">
                <h2 className="text-xl font-bold text-white undertile-headertitle"> Ad Space</h2>
                <ul className="list-none pl-0 space-y-2">
                    {["Well, this website still needs a little advertising space — after all, keeping the server running every year isn’t exactly cheap.",
                        "If you’re interested in placing an ad, feel free to get in touch with me!"
                    ].map((text, i) => (
                        <li key={i} className="undertale-li" data-icon={i % 7}>{text}</li>
                    ))}
                </ul>
                <p className="undertale-li">Of course, you can also visit the site’s main page: <a href="/">Fishlog.</a></p>
            </div>
        </>
    );
}