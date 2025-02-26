/** @jsxImportSource @emotion/react */
import { css } from "@emotion/react";
import { theme } from "../styles/theme";

const formGroupStyle = css`
    margin-bottom: ${theme.spacing.md};
`;

const inputStyle = css`
    font-family: ${theme.fonts.code};
    width: 100%;
    padding: ${theme.spacing.sm};
    border: 1px solid ${theme.colors.border};

    &:focus {
    outline: none;
    border-color: ${theme.colors.accent};
    }
`;

const textAreaStyle = css`
    ${inputStyle};
    min-height: 80px;
    resize: vertical;
`;

const labelStyle = css`
    display: block;
    margin-bottom: ${theme.spacing.sm};
    font-size: 14px;
    color: ${theme.colors.text.secondary};
`;

const FormField = ({ label, name, type, value, onChange, required = false }) => {
    if (type === 'textarea') {
        return (
            <div css={formGroupStyle}>
                <label css={labelStyle}>
                    {label} {required && '*'}
                </label>
                <textarea
                    css={textAreaStyle}
                    name={name}
                    value={value}
                    onChange={onChange}
                    required={required}
                />
            </div>
        );
    }

    return (
        <div css={formGroupStyle}>
            <label css={labelStyle}>
                {label} {required && '*'}
            </label>
            <input
                css={inputStyle}
                type={type}
                name={name}
                value={value}
                onChange={onChange}
                required={required}
            />
        </div>
    );
};

export default FormField