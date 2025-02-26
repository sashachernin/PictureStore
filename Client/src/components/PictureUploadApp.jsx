/** @jsxImportSource @emotion/react */
import { css } from '@emotion/react';
import usePictureForm from '../hooks/usePictureForm';
import usePicturesTable from '../hooks/usePicturesTable';
import PictureUploadForm from './PictureUploadForm';
import PicturesTable from './PicturesTable';
import { theme } from "../styles/theme";

const containerStyle = css`
  max-width: 1000px;
  margin: 0 auto;
  padding: ${theme.spacing.lg};
  font-family: ${theme.fonts.code};
  background: ${theme.colors.background};
`;

const cardStyle = css`
  background: ${theme.colors.surface};
  margin-bottom: ${theme.spacing.lg};
  padding: ${theme.spacing.lg};
  border: 1px solid ${theme.colors.border};
`;

const PictureUploadApp = () => {
    const { pictures, loading, selectedRows, addPicture, handleRowClick } = usePicturesTable();

    const {
        formKey,
        formData,
        error,
        loading: formLoading,
        handleInputChange,
        handleFileChange,
        handleReset,
        handleSubmit,
    } = usePictureForm(pictures, addPicture);

    return (
        <div css={containerStyle}>
            <PictureUploadForm
                formKey={formKey}
                formData={formData}
                error={error}
                loading={formLoading}
                onInputChange={handleInputChange}
                onFileChange={handleFileChange}
                onSubmit={handleSubmit}
                onReset={handleReset}
            />

            <div css={cardStyle}>
                <PicturesTable
                    pictures={pictures}
                    loading={loading}
                    selectedRows={selectedRows}
                    onRowClick={handleRowClick}
                />
            </div>
        </div>
    );
};

export default PictureUploadApp;
