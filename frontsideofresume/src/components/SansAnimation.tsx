import React, { useRef, useEffect } from "react";
import { anim } from "../assets/sans_anim_data";
const SansAnimation: React.FC = () => {
    const canvasRef = useRef<HTMLCanvasElement>(null);

    useEffect(() => {
        const canvas = canvasRef.current;
        if (!canvas) return;
        const ctx = canvas.getContext("2d");
        if (!ctx) return;

        const drawPixel = (x: number, y: number, value: number) => {
            ctx.fillStyle = value ? "#fff" : "#000";
            ctx.fillRect(x, y, 1, 1);
        };

        const drawFrame = (diff: any) => {
            // 每一帧都从背景构建
            const frame = anim.background.map((row: number[]) => [...row]);
            diff.changes.forEach(([x, y, v]: [number, number, number]) => {
                frame[y][x] = v;
            });
            for (let y = 0; y < anim.height; y++) {
                for (let x = 0; x < anim.width; x++) {
                    drawPixel(x, y, frame[y][x]);
                }
            }
        };

        let frameIndex = 0;
        const nextFrame = () => {
            drawFrame(anim.diffs[frameIndex]);
            const delay = anim.diffs[frameIndex].delay;
            frameIndex = (frameIndex + 1) % anim.diffs.length;
            setTimeout(nextFrame, delay);
        };

        nextFrame();
    }, []);

    return (
        <canvas
            className="undertale-sans-canvas"
            ref={canvasRef}
            width={anim.width}
            height={anim.height}
            style={{
                imageRendering: "pixelated",
                background: "black",
                display: "block",
            }}
        />
    );
};

export default SansAnimation;
