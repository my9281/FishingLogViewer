 
import   { useState } from 'react';  

export default function Notes() { 
    const [title, setTitle] = useState('');
    const [user, setUser] = useState('');
    const [text, setText] = useState('');

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
                <h2 className="text-xl font-bold text-white undertile-headertitle"> Ad Space</h2>
                {["Well, this website still needs a little advertising space — after all, keeping the server running every year isn’t exactly cheap.",
                    "If you’re interested in placing an ad, feel free to get in touch with me!"
                ].map((text, i) => (
                        <li key={i} className="undertale-li" data-icon={i % 7}>{text}</li>
                    ))}
                <p className="undertale-li">Of course, you can also visit the site’s main page: <a href="/">Fishlog.</a></p>
            </div>
        </>
    );
}