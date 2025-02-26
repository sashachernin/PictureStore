/** @jsxImportSource @emotion/react */
import { css } from "@emotion/react";
import { theme } from "../styles/theme";

const errorStyle = css`
  color: ${theme.colors.error};
  border-left: 3px solid ${theme.colors.error};
  padding: ${theme.spacing.sm} ${theme.spacing.md};
  margin-bottom: ${theme.spacing.md};
  font-size: 14px;
`;

const ErrorMessage = ({ message }) => {
    if (!message) return null;

    return (
        <div css={errorStyle}>
            {message}
        </div>
    );
};

export default ErrorMessage