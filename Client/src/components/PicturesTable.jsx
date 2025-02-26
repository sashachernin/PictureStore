/** @jsxImportSource @emotion/react */
import { css } from "@emotion/react";
import { theme } from "../styles/theme";

const table = css`
  width: 100%;
  border-collapse: collapse;
  font-family: ${theme.fonts.code};
`;

const tableHead = css`
  border-bottom: 1px solid ${theme.colors.border};
`;

const tableCell = css`
  padding: ${theme.spacing.sm};
  font-size: 14px;
  text-align: left;
`;

const tableHeader = css`
  ${tableCell};
  font-weight: 500;
  color: ${theme.colors.text.secondary};
`;

const row = css`
  border-bottom: 1px solid ${theme.colors.border};
  cursor: pointer;
  
  &:hover {
    background: ${theme.colors.background};
  }
`;

const selectedRow = css`
  background: rgba(13, 110, 253, 0.1);
  
  &:hover {
    background: rgba(13, 110, 253, 0.15);
  }
`;

const emptyMessage = css`
  padding: ${theme.spacing.lg};
  text-align: center;
  color: ${theme.colors.text.secondary};
`;

const PicturesTable = ({ pictures, loading, selectedRows, onRowClick }) => {
    if (loading && !pictures.length) {
        return <p css={emptyMessage}>Loading pictures...</p>;
    }

    return (
        <table css={table}>
            <thead css={tableHead}>
                <tr>
                    <th css={tableHeader}>ID</th>
                    <th css={tableHeader}>Name</th>
                </tr>
            </thead>
            <tbody>
                {pictures.length === 0 ? (
                    <tr>
                        <td colSpan="2" css={emptyMessage}>
                            No pictures uploaded yet
                        </td>
                    </tr>
                ) : (
                    pictures.map(picture => (
                        <tr
                            key={picture.id}
                            onClick={() => onRowClick(picture.id)}
                            css={[
                                row,
                                selectedRows.includes(picture.id) && selectedRow
                            ]}
                        >
                            <td css={tableCell}>{picture.id}</td>
                            <td css={tableCell}>{picture.name}</td>
                        </tr>
                    ))
                )}
            </tbody>
        </table>
    );
};

export default PicturesTable;