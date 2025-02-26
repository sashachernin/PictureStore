/** @jsxImportSource @emotion/react */
import { css } from "@emotion/react";
import ErrorMessage from "./ErrorMessage";
import FormField from "./FormField";
import FileInput from "./FileInput";
import Button from "./Button";
import { theme } from "../styles/theme";

const formStyle = css`
  margin-bottom: ${theme.spacing.lg};
`;

const buttonGroupStyle = css`
  margin-top: ${theme.spacing.md};
`;

const PictureUploadForm = ({
    formKey,
    formData,
    error,
    loading,
    onInputChange,
    onFileChange,
    onSubmit,
    onReset
}) => {
    return (
        <div css={formStyle}>
            <ErrorMessage message={error} />
            <form onSubmit={onSubmit} key={formKey}>
                <FormField
                    label="Name"
                    name="name"
                    type="text"
                    value={formData.name}
                    onChange={onInputChange}
                    required={true}
                />

                <FormField
                    label="Description (optional)"
                    name="description"
                    type="textarea"
                    value={formData.description}
                    onChange={onInputChange}
                />

                <FormField
                    label="Date & Time (optional)"
                    name="dateTime"
                    type="datetime-local"
                    value={formData.dateTime}
                    onChange={onInputChange}
                />

                <FileInput
                    label="Picture File"
                    name="file"
                    onChange={onFileChange}
                    required={true}
                />

                <div css={buttonGroupStyle}>
                    <Button
                        type="submit"
                        disabled={loading}
                    >
                        {loading ? 'Uploading...' : 'Add'}
                    </Button>

                    <Button
                        type="button"
                        onClick={onReset}
                    >
                        Reset
                    </Button>
                </div>
            </form>
        </div>
    );
};

export default PictureUploadForm;