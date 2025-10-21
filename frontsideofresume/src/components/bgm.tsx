import { useEffect, useRef, useState } from "react";
export default function FloatingMusicPlayer() {
  const audioRef = useRef<HTMLAudioElement | null>(null);
  const [isPlaying, setIsPlaying] = useState(false);

  const togglePlay = () => {
    const audio = audioRef.current;
    if (!audio) return;

    if (isPlaying) {
      audio.pause();
    } else {
      audio.play().catch(() => {
        console.warn("Autoplay blocked");
      });
    }
    setIsPlaying(!isPlaying);
  };

  useEffect(() => {
    const audio = audioRef.current;
    if (!audio) return;

    // 自动播放尝试（部分浏览器需用户交互）
    audio.play().then(() => {
      setIsPlaying(true);
    }).catch(() => {
      // 被拦截也没关系，等待用户点击播放
    });

    return () => {
      audio.pause();
    };
  }, []);

  return (
    <div className="fixed bottom-4 right-4 z-50 bg-black/80 text-white px-4 py-2 rounded-xl shadow-lg flex items-center space-x-2 text-sm font-mono">
      <span>🎵 Home - Toby Fox </span>
      <button onClick={togglePlay} className="undertale-bgm-button">
        {isPlaying ? "⏸️" : "▶️"}
      </button>
      <audio ref={audioRef} loop preload="auto">
        <source src="/assets/bgm.ogg" type="audio/ogg" /> 
      </audio>
    </div>
  );
}