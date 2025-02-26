import { useState, useEffect } from 'react';
import pictureService from '../services/pictureService';

const usePicturesTable = () => {
    const [pictures, setPictures] = useState([]);
    const [loading, setLoading] = useState(false);
    const [selectedRows, setSelectedRows] = useState([]);

    useEffect(() => {
        fetchPictures();
    }, []);

    const fetchPictures = async () => {
        try {
            setLoading(true);
            const data = await pictureService.fetchPictures();
            setPictures(data);
        } catch (error) {
            console.error('Error fetching pictures:', error);
        } finally {
            setLoading(false);
        }
    };

    const addPicture = (picture) => {
        setPictures(prev => [...prev, picture]);
    };

    const handleRowClick = (id) => {
        setSelectedRows(prev =>
            prev.includes(id)
                ? prev.filter(rowId => rowId !== id)
                : [...prev, id]
        );
    };

    return { pictures, loading, selectedRows, addPicture, handleRowClick };
};

export default usePicturesTable;
