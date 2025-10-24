import { defineConfig } from 'vite';
import plugin from '@vitejs/plugin-react'; 
export default defineConfig({
    plugins: [plugin()],
    server: {
        port: 8102,
    },
    build: {
        rollupOptions: {
            output: {
                entryFileNames: '[name].js',
                chunkFileNames: '[name].js',
                assetFileNames: '[name][extname]',
            },
        }
    }
})
