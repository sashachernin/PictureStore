/** @jsxImportSource @emotion/react */
import { css } from "@emotion/react";
import { theme } from "../styles/theme";

const formGroupStyle = css`
    margin-bottom: ${theme.spacing.md};
`;

const fileInputStyle = css`
  font-family: ${theme.fonts.code};
  margin-top: ${theme.spacing.sm};
`;

const labelStyle = css`
  display: block;
  margin-bottom: ${theme.spacing.sm};
  font-size: 14px;
  color: ${theme.colors.text.secondary};
`;

const FileInput = ({ label, name, onChange, required = false }) => {
    return (
        <div css={formGroupStyle}>
            <label css={labelStyle}>
                {label} {required && '*'}
            </label>
            <input
                css={fileInputStyle}
                type="file"
                name={name}
                onChange={onChange}
                accept="image/*"
                required={required}
            />
        </div>
    );
};

export default FileInput