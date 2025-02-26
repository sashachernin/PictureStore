/** @jsxImportSource @emotion/react */
import { css } from "@emotion/react";
import { theme } from "../styles/theme";

const buttonStyle = css`
  font-family: ${theme.fonts.code};
  padding: ${theme.spacing.sm} ${theme.spacing.md};
  border: 1px solid ${theme.colors.border};
  background: transparent;
  cursor: pointer;
  margin-right: ${theme.spacing.sm};
  &:hover {
    background: ${theme.colors.surface};
  }
`
const Button = ({ type, onClick, disabled, children }) => {
  return (
    <button
      css={buttonStyle}
      type={type}
      onClick={onClick}
      disabled={disabled}
    >
      {children}
    </button>
  );
};

export default Button