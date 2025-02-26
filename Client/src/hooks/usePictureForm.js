import { useState } from 'react';
import pictureService from '../services/pictureService';

const usePictureForm = (pictures, addPicture) => {
    const [formKey, setFormKey] = useState(Date.now());
    const [formData, setFormData] = useState({
        name: '',
        description: '',
        dateTime: '',
        content: null,
    });
    const [error, setError] = useState('');
    const [loading, setLoading] = useState(false);

    const handleInputChange = (e) => {
        const { name, value } = e.target;
        setFormData(prev => ({ ...prev, [name]: value }));
        setError('');
    };

    const handleFileChange = (e) => {
        setFormData(prev => ({ ...prev, content: e.target.files[0] }));
        setError('');
    };

    const handleReset = () => {
        if (window.confirm('Are you sure you want to reset the form?')) {
            setFormData({
                name: '',
                description: '',
                dateTime: '',
                content: null,
            });
            setError('');
            setFormKey(Date.now());
        }
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        if (!formData.name || !formData.content) {
            setError('Name and file are required');
            return;
        }

        // Validate unique name
        if (pictures.some(picture => picture.name === formData.name)) {
            setError('A picture with this name already exists');
            return;
        }

        try {
            setLoading(true);
            const result = await pictureService.uploadPicture(formData);

            addPicture({
                id: result.id,
                name: formData.name,
                description: formData.description,
                dateTime: formData.dateTime,
                content: formData.content,
            });

            // Reset form after successful upload
            setFormData({
                name: '',
                description: '',
                dateTime: '',
                content: null,
            });
            setError('');
            setFormKey(Date.now());
        } catch (error) {
            console.error('Error uploading picture:', error);
            setError(error.message || 'An error occurred while uploading the picture');
        } finally {
            setLoading(false);
        }
    };

    return {
        formKey,
        formData,
        error,
        loading,
        handleInputChange,
        handleFileChange,
        handleReset,
        handleSubmit,
    };
};

export default usePictureForm;
