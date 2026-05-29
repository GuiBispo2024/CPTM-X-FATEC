export default {
  content: [
    "./index.html",
    "./src/**/*.{vue,js,ts,jsx,tsx}",
  ],
  theme: {
    extend: {
      colors: {
        primary: {
          DEFAULT: '#dc2626', // Vermelho CPTM
          dark: '#b91c1c',
          light: '#ef4444',
        },
        secondary: {
          DEFAULT: '#16a34a', // Verde
          dark: '#15803d',
          light: '#22c55e',
        },
        success: '#16a34a',
        warning: '#f59e0b',
        danger: '#dc2626',
        white: '#ffffff',
      }
    },
  },
  plugins: [],
}