const API_BASE_URL = import.meta.env.VITE_API_URL || "http://localhost:8080";

const pictureService = {
    fetchPictures: async () => {
        const response = await fetch(`${API_BASE_URL}/api/pictures`);
        if (!response.ok) {
            throw new Error('Failed to fetch pictures');
        }
        return response.json();
    },

    uploadPicture: async (formData) => {
        const form = new FormData();
        form.append('name', formData.name);

        if (formData.description) {
            form.append('description', formData.description);
        }

        if (formData.dateTime) {
            form.append('dateTime', formData.dateTime);
        }

        form.append('content', formData.content);

        const response = await fetch(`${API_BASE_URL}/api/pictures`, {
            method: 'POST',
            body: form
        });

        if (!response.ok) {
            const errorData = await response.json();
            throw new Error(errorData.message || 'Failed to upload picture');
        }

        return response.json();
    }
};

export default pictureService;